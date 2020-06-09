using System;
using System.Collections.Generic;

namespace Chat
{
    /// <summary>
    /// Структура, которая содержит в себе необходимые
    /// данные для составления ответа. 
    /// Для каждаго типа вопросов определяетс своя структура.
    /// </summary>
    public struct PackForAnswer
    {
        /// <summary>
        /// Позиция ответа на вопрос среди доп. слов.
        /// </summary>
        byte location;
        public byte Location
        {
            get => location;
            set
            {
                if (ChooseWord != null)
                    if (value > ChooseWord.Count) throw new Exception("Позиция ответа больше кол-ва доп слов.");
                location = value;
            }
        }

        /// <summary>
        /// Ответ на поставленный вопрос.
        /// </summary>
        public Func<string, string> Answer { get; set; }

        /// <summary>
        /// Методы для выбора доп. слов.
        /// Каждый метод соответствует определенному набору слов, 
        /// из которого этот метод и выбирает одно.
        /// Эти слова являются лишь дополнением к основному ответу.
        /// </summary>
        List<Func<string>> chooseWord;
        public List<Func<string>> ChooseWord
        {
            get => chooseWord;
            set
            {
                if (Location != 0)
                    if (value.Count < Location) throw new Exception("Кол-во доп слов меньше позиции ответа.");
                chooseWord = value;
            }
        }

        /// <summary>
        /// Конструктор инициализирует поля, чтобы по ним составить ответ
        /// </summary>
        public PackForAnswer(byte loc, Func<string, string> answer,
            params Func<string>[] chooseW)
        {
            chooseWord = null;
            location = 0;
            Answer = answer;

            ChooseWord = new List<Func<string>>(chooseW);
            Location = loc;
        }
    }
}
