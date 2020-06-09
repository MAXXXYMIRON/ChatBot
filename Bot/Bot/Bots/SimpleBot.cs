using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using static Chat.Words.Signs;
using static Chat.Words.SimpleWords;

namespace Chat.Bots
{
    public class SimpleBot : StyleOfBot
    {
        internal override Regex NotUnderstand { get; } = new Regex("некорректный вопрос");

        public SimpleBot() : base("SimpleBot")
        {
            Pack = new Dictionary<Regex, PackForAnswer>
            {
                //Приветствие
                { new Regex(@"\s?прив.*|\s?\w*дравствуй.*|\s?\w*даров.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(2, Hello,  Greeting, Space, Dot)
                },
                //Время
                { new Regex(@"\s?врем\.*|\s?который час.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(4, Time,  Input, Comma, Now, Space, Comma, Appeal, Dot)
                },
                //Дата
                { new Regex(@"\s?дата.*|\s?числ.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(4, Date,  Input, Comma, Now, Space, Comma, Appeal, Dot)
                },
                //Как дела?
                { new Regex(@"\s?дела.*|\s?жизнь.*|\s?чувств.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(1, Void,  State, Dot)
                },
                //Благодарность
                { new Regex(@"\s?\.*пасиб.*|\s?благодар.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(1, Void,  Welcome, Comma, Appeal, ExclamationMark)
                },
                //Сумма
                { new Regex(@"\s?сумм.*|\s?сложи.*|\s?склад.*|\s?.*бав.*|\s?плюс.*|.*\+.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(4, Add,  Input, Comma, Some, Space, Dot)
                },
                //Разность
                { new Regex(@"\s?выч.*|\s?отним.*|\s?минус.*|\s?разность.*|.*\-.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(2, Sub,  Give, Line, Dot)
                },
                //Произведение
                { new Regex(@"\s?.*множ.*|\s?произв.*|.*\*.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(4, Mul,  Input, Comma, Some, Space, Comma, Appeal, Dot)
                },
                //Частное
                { new Regex(@"\s?.*дели.*|\s?частное.*|.*\/.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(4, Div,  Give, Space, Appeal, Line, Dot)
                },
                //Картинка с APOD
                { new Regex(@"apod",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(0, APOD)
                },
                //Прощание
                { new Regex(@"\s?пок.*|\s?прощ.*|\s?досвид.*|\s?до встре.*",
                RegexOptions.IgnoreCase),
                    new PackForAnswer(2, Void,  Bye, Comma, Thanks, Space, Appeal, Dot)
                },
                //Некорректный вопрос
                { NotUnderstand,
                    new PackForAnswer(2, Void,  Appeal, Comma, What, Dot)
                }
            };
        }


        /// <summary>
        /// Справка о боте. 
        /// </summary>
        protected override void MakeHelp()
        {
            HelpWrite.WriteLine("Набор слов, на которые может ответить \"Простой Бот\".\n" +
                "Приветствие. Слова типа - \"Привет, здравствуй, здарова\".\n" +
                "Узнать время. Слова типа - \"Время, который час\".\n" +
                "Узнать дату. Слова типа - \"Какое число, дата\".\n" +
                "Спросить как дела. Слова типа - \"Как дела, жизнь, самочувствие, как себя чувствуешь\".\n" +
                "Сложить числа. Слова типа - \"Сумма, сложи, складывай, прибавь, сплюсуй, +\".\n" +
                "Отнять числа. Слова типа - \"Вычти, отними, минус, разность, -\".\n" +
                "Перемножить числа. Слова типа - \"Перемнож, произведение, *\".\n" +
                "Разделить числа. Слова типа - \"Раздели, частное, \\\".\n" +
                "Изображение с APOD. Слова типа - \"apod\".\n" +
                "Прощание. Слова типа - \"Пока, прощай, досвидания, до встречи\".\n\n" +
                "Разделяйте разные вопросы точками, знаками вопроса и знаками восклицания.\n" +
                "Используйте запчтые для вещественных чисел.\n" +
                "Если в предложении нет слов, корни которых совпадают с корнями предоставленных слов,\n" +
                "Бот ответит непониманием.");
        }



        /// <summary>
        /// Ответ на приветствие.
        /// </summary>
        private string Hello(string arg)
        {
            return UserOfBot.Name;
        }

        /// <summary>
        /// Текущее время. 
        /// </summary>
        private string Time(string arg)
        {
            return DateTime.Now.ToString("HH:mm");
        }

        /// <summary>
        /// Текущая дата. 
        /// </summary>
        private string Date(string arg)
        {
            return DateTime.Now.ToString("dd.MM.yy");
        }

        /// <summary>
        /// Нахождение чисел в arg и возврат их суммы.
        /// </summary>
        private string Add(string arg)
        {
            MatchCollection numbers = Regex.Matches(arg, @"(\d+\,\d+)|(\d+)");
            if (numbers.Count == 0) return "ничего";
            double result = 0;

            foreach (Match number in numbers)
            {
                result += Convert.ToDouble(number.Value);
            }

            return result.ToString("f3");
        }

        /// <summary>
        /// Нахождение чисел в arg и возврат их разности.
        /// </summary>
        private string Sub(string arg)
        {
            MatchCollection numbers = Regex.Matches(arg, @"(\d+\,\d+)|(\d+)");
            if (numbers.Count == 0) return "нисколько";
            double result = Convert.ToDouble(numbers[0].Value);

            for (int i = 1; i < numbers.Count; i++)
            {
                result -= Convert.ToDouble(numbers[i].Value);
            }

            return result.ToString("f3");
        }

        /// <summary>
        /// Нахождение чисел в arg и возврат их произведения.
        /// </summary>
        private string Mul(string arg)
        {
            MatchCollection numbers = Regex.Matches(arg, @"(\d+\,\d+)|(\d+)");
            if (numbers.Count == 0) return "абсолютно ничего";
            double result = 1;

            foreach (Match number in numbers)
            {
                result *= Convert.ToDouble(number.Value);
            }

            return result.ToString("f3");
        }

        /// <summary>
        /// Нахождение чисел в arg и возврат их частного.
        /// </summary>
        private string Div(string arg)
        {
            MatchCollection numbers = Regex.Matches(arg, @"(\d+\,\d+)|(\d+)");
            if (numbers.Count == 0) return "немножечко пустоты";
            double result = Convert.ToDouble(numbers[0].Value);

            for (int i = 1; i < numbers.Count; i++)
            {
                result /= Convert.ToDouble(numbers[i].Value);
            }

            return result.ToString("f3");
        }

        /// <summary>
        /// Фото с APOD.
        /// </summary>
        private string APOD(string arg)
        {
            //URL актуальной для данной даты страницы APOD.
            string urlOfPage = "https://apod.nasa.gov/apod/ap" +
                DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("d2")
                + (DateTime.Now.Day - 1).ToString("d2") + ".html";

            //Данные страницы.
            string dataFromPage;
            //URL изображения со страницы.
            string urlOfImage;
            //Коллекция для нахождения названия изображения в dataFromPage,
            //чтобы сформирровать urlOfImage.
            MatchCollection imageCollectioons;

            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse;
            try
            {
                //Взятие данных со страницы.
                httpWebRequest = (HttpWebRequest)WebRequest.Create(urlOfPage);
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    dataFromPage = streamReader.ReadToEnd();
                }
            }
            catch
            {
                //Возврат URL актуальной для данной даты, в случае неудачи.
                return urlOfPage;
            }

            //Поиск названия изображения.
            imageCollectioons =
                Regex.Matches(dataFromPage, @"\/.*jpg");

            //Возврат URL актуальной для данной даты, в случае неудачи.
            if (imageCollectioons.Count == 0) return urlOfPage;

            //Формирование URL изображения со страницы.
            urlOfImage = "https://apod.nasa.gov/apod/image" + imageCollectioons[0].Value;


            try
            {
                //Запись данных со страницы в файл
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(urlOfImage, @"Image.jpg");
                }
            }
            catch
            {
                //Возврат URL актуальной для данной даты, в случае неудачи.
                return urlOfPage;
            }

            return @"Image.jpg";
        }
    }
}
