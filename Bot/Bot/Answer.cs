using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chat
{
    /// <summary>
    /// Класс составляет ответ по полученному индексу ответа.
    /// </summary>
    static class Answer
    {
        /// <summary>
        /// Список, в который добавляются солва при составлении ответа.
        /// </summary>
        static List<string> Words = new List<string>();
        /// <summary>
        /// Ответ.
        /// </summary>
        static string AnswerIsReady = "";

        /// <summary>
        /// Поставить в верхний регистр первую букву строки str. 
        /// </summary>
        static string FirstUp(string str)
        {
            string temp = "";
            temp += str[0].ToString().ToUpper();
            for (int i = 1; i < str.Length; i++)
            {
                temp += str[i];
            }
            return temp;
        }

        /// <summary>
        /// Составить ответ из данных, на которые указывает indexOfAnswer и 
        /// с использованием question.
        /// </summary>
        public static string MakeAnswer(Regex indexOfAnswer, string question)
        {
            AnswerIsReady = ""; 

            //Добавить в список дополнительные слова.
            for (int i = 0; i < Bot.Style.Pack[indexOfAnswer].ChooseWord.Count; i++)
            {
                Words.Add(Bot.Style.Pack[indexOfAnswer].ChooseWord[i]());
            }
            //Вставить на нужную позицию в списке ответ на вопрос.
            Words.Insert(Bot.Style.Pack[indexOfAnswer].Location, 
                Bot.Style.Pack[indexOfAnswer].Answer(question));

            //Сделать первое слово с заглавной буквы.
            Words[0] = FirstUp(Words[0]);

            //Сформировать ответ.
            for (int i = 0; i < Words.Count; i++)
            {
                AnswerIsReady += Words[i];
            }

            Words.Clear();
            return AnswerIsReady;
        }
    }
}
