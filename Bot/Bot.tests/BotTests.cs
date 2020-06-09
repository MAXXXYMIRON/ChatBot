using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chat.tests
{
    [TestClass]
    public class BotTests
    {
        Bot TestBot = new Bot(new Bots.SimpleBot(),
            new Users.SimpleUser("Максим", "Никитин", Sex.Male, new DateTime(2001, 1, 30)));

        string[] Answers;


        [TestMethod]
        public void ToAsk_Hello_answer()
        {
            Answers = TestBot.ToAsk("Привет бот очень рад тебя видеть. Здравствуй мой дорогой. и здарова.");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Time_answer()
        {
            Answers = TestBot.ToAsk("Бот скажи сколько времени. плеаз. Бот скажи ка мне который час.");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Date_answer()
        {
            Answers = TestBot.ToAsk("Какая на дворе дата? Че по числу?");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Deal_answer()
        {
            Answers = TestBot.ToAsk("Как у тебя дела? Как жизнь молодая? Хорошо себя чувствуешь?");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Thanks_answer()
        {
            Answers = TestBot.ToAsk("Спасибо тебе. Премтоного благодарен.");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Add_answer()
        {
            Answers = TestBot.ToAsk("Сколько будет 3 + 3? Суммируй 3 и 3. Сложи 3 с 3. Складывай 3 и3. 3 плюс 3");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Sub_answer()
        {
            Answers = TestBot.ToAsk("Вычти 2 и 5. от 5 отними 2. 2 минус 5. какова разность 2 и 5. 2 - 5");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Mul_answer()
        {
            Answers = TestBot.ToAsk("Произведение 4 и 5! перемнож 4 и 5! умножь 4 на 5. 4 * 5");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Div_answer()
        {
            Answers = TestBot.ToAsk("Подели 9 на 3. частное 6,2 и 3,1. 3/1");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_Bye_answer()
        {
            Answers = TestBot.ToAsk("Прощай. покульки. досвидания. до встречи");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        [TestMethod]
        public void ToAsk_APOD_answer()
        {
            Answers = TestBot.ToAsk("Бот покажи картинку с apod");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }
    }
}
