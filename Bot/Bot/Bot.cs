using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Chat

{
    public class Bot
    {
        /// <summary>
        /// Вопросы и индексы ответов, полученные от Question
        /// </summary>
        List<(string, Regex)> IndexesOfAnswers;



        /// <summary>
        /// Стиль вопросов и отвтов бота.
        /// </summary>
        public static StyleOfBot Style { get; set; }

        /// <summary>
        /// Текущий собеседник бота.
        /// </summary>
        public User User
        {
            get => Style.UserOfBot;
            set => Style.UserOfBot = value;
        }

        public Bot() { }
        public Bot(StyleOfBot style)
        {
            Style = style;
        }
        public Bot(StyleOfBot style, User user) : this(style)
        {
            Style.UserOfBot = user;
        }

        /// <summary>
        /// Получить массив ответов на поставленные вопросы\вопрос.
        /// </summary>
        public string[] ToAsk(string quastion)
        {
            string[] Answers = null;
            //Получить индексы для составления ответов.
            IndexesOfAnswers = Question.GetAnswer(quastion);

            //Если индексы есть составить ответ.
            if (IndexesOfAnswers.Count > 0)
            {
                Answers = new string[IndexesOfAnswers.Count];
                for (int i = 0; i < Answers.Length; i++)
                {
                    Answers[i] = Answer.MakeAnswer(IndexesOfAnswers[i].Item2, IndexesOfAnswers[i].Item1);
                }
            }
            //Иначе составить ответ на некорректно поставленный вопрос.
            else
            {
                Answers = new string[1];
                Answers[0] = Answer.MakeAnswer(Style.NotUnderstand, "");
            }

            return Answers;
        }
    }
}
