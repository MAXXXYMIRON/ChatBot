using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chat
{
    /// <summary>
    /// Класс анализирует заданные вопрос, разделяя его по 
    /// знакам пунктуации на отдельные вопросы и находя для
    /// каждаго вопроса индекс, указывающий на структуру 
    /// для составления ответа на найденный вопрос.
    /// </summary>
    static class Question
    {
        /// <summary>
        /// Список кортежей, в картеже хранится вопрос и соответствующий ему Regex.
        /// </summary>
        static List<(string, Regex)> arrayQuestions = new List<(string, Regex)>();
        /// <summary>
        /// Конец предыдущего вопроса и начало следующего.
        /// </summary>
        static int dotBefore = 0;
        /// <summary>
        /// Переменная для записи найденного вопроса.
        /// </summary>
        static string quest = "";

        /// <summary>
        /// Вернет список кортежей с вопросами и соответствующими им
        /// индексами ответов.
        /// </summary>
        public static List<(string, Regex)> GetAnswer(string question)
        {
            arrayQuestions.Clear();
            dotBefore = 0;
            quest = "";

            //Поиск вопросов в предложениии.
            for (int i = 0; i < question.Length; i++)
            {
                if (question[i] == '.' || question[i] == '!' || question[i] == '?')
                {
                    quest = question.Substring(dotBefore, i - dotBefore);

                    //Поиск индекса соответствующего вопросу.
                    foreach (var item in Bot.Style.Pack)
                    {
                        if (item.Key.IsMatch(quest))
                        { 
                            //Добавление вопроса и индекса в список.
                            arrayQuestions.Add((quest, item.Key));
                            break;
                        }
                    }

                    dotBefore = i + 1;
                }
            }
            
            //Поиск индекса для всего вопроса или для оставшейся его части.
            if((question.Length - dotBefore) > 1)
            {
                quest = question.Substring(dotBefore, question.Length - dotBefore);

                foreach (var item in Bot.Style.Pack)
                {
                    if (item.Key.IsMatch(quest))
                    {
                        arrayQuestions.Add((quest, item.Key));
                        break;
                    }
                }
            }

            return arrayQuestions;
        }
    }
}
