using System;
using System.Collections.Generic;

namespace Chat.Words
{
    /// <summary>
    /// Статический класс предоставляющий наборы слов, обозначающих одно понятие,
    /// и метод для выбора слова из набора
    /// </summary>
    public static class SimpleWords
    {
        static Random ToChoose;
        static int Index = 0;
        static SimpleWords()
        {
            ToChoose = new Random();
        }

        //Наборы слов   

        /// <summary>
        /// Набор слов бота для приветствий
        /// </summary>
        static List<string> GreetingWords = null;
        /// <summary>
        /// Набор слов бота для благодарностей
        /// </summary>
        static List<string> ThanksWords = null;
        /// <summary>
        /// Набор слов бота для указания на сегодняшний день
        /// </summary>
        static List<string> NowWords = null;
        /// <summary>
        /// Набор слов бота для обращений к пользователю
        /// </summary>
        static List<string> AppealWords = null;
        /// <summary>
        /// Набор слов бота для описания его состояния
        /// </summary>
        static List<string> StateWords = null;
        /// <summary>
        /// Набор слов бота для отказов
        /// </summary>
        static List<string> RejectsWords = null;
        /// <summary>
        /// Набор слов бота для извинений
        /// </summary>
        static List<string> ApologysWords = null;
        /// <summary>
        /// Набор вводных слов
        /// </summary>
        static List<string> InputWords = null;
        /// <summary>
        /// Набор слов бота для прощаний
        /// </summary>
        static List<string> ByeWords = null;
        /// <summary>
        /// Набор слов бота для ответов на благодарности
        /// </summary>
        static List<string> WelcomeWords = null;
        /// <summary>
        /// Набор слов бота для ответов при непонимании
        /// </summary>
        static List<string> WhatWords = null;
        /// <summary>
        /// Набор слов бота для ответов при приближения
        /// </summary>
        static List<string> SomeWords = null;
        /// <summary>
        /// Набор слов бота для ответов для предоставления чего-либо
        /// </summary>
        static List<string> GiveWords = null;
        /// <summary>
        /// Кого?
        /// </summary>
        static List<string> WhoWords = null;
        /// <summary>
        /// Кому?
        /// </summary>
        static List<string> ForWhoWords = null;



        //Методы выбора слов из набора

        /// <summary>
        /// Метод для выбора слов из набора "Приветствия"
        /// </summary>
        public static string Greeting()
        {
            if(GreetingWords == null) GreetingWords = new List<string>
            {"доброе утро", "добрый день", "доброй ночи", "добрый вечер",
            "добрейший вечерочек", "вечер в чат",
            "здравтсвуйте", "привет", "доброго времени суток", "hello",
            "невероятно рад тебя слышать", "здравствуй", "хай", "какая встреча",
            "не здоровоюсь", "рад приветствовать"};

            //Приветствовать с учетом времени суток
            if(ToChoose.Next(0, 5) == 0)
            {
                Time.Time now = Time.Time.Now;
                if (now.Hour >= 21 || now.Hour <= 3)
                    return GreetingWords[2]; // Ночь
                if (now.Hour >= 4 && now.Hour <= 12)
                    return GreetingWords[0]; //Утро
                if (now.Hour >= 13 && now.Hour <= 18)
                    return GreetingWords[1]; //День
                if (now.Hour >= 18)
                    return GreetingWords[ToChoose.Next(3, 5)]; //Вечер
            }

            Index = ToChoose.Next(6, GreetingWords.Count);

            if (Index == GreetingWords.Count - 1) return (GreetingWords[Index] + " " + Who());
            return GreetingWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Благодарности"
        /// </summary>
        public static string Thanks()
        {
            if (ThanksWords == null) ThanksWords = new List<string>
            { "благодарю", "спасибо", "спасибочки", "премного благодпрен",
            "огромное спасибо", "merssi", "si", "я ценю это", "я у вас в долгу" };

            Index = ToChoose.Next(0, ThanksWords.Count);

            return (Index == 0) ? ThanksWords[Index] + " " + Who()
                : (Index < 5) ? ThanksWords[Index] + " " + ForWho()
                : ThanksWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Сейчас"
        /// </summary>
        public static string Now()
        {
            if (NowWords == null) NowWords = new List<string>
            { "сегодня", "сейчас", "на данный момент", "на дворе", "за окном",
            "в эту секунду", "на текущий момент", "в эту минуту", "в этот час",
            "на момент твоего вопроса" };

            return NowWords[ToChoose.Next(0, NowWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Обращения"
        /// </summary>
        public static string Appeal()
        {
            if (AppealWords == null) AppealWords = new List<string>
            {"мой друг", "дружище", "мой любимый пользователь", "самурай",
            "боец", "рыбка моя", "котенок", "джедай", "коженный ублюдок",
            "будущий член моей колонии рабов", "супер герой", "Бэтмен", "дорогуша",
            "курсант", "салага", "сэр", "мюсье"};

            return AppealWords[ToChoose.Next(0, AppealWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Описание состояния бота"
        /// </summary>
        public static string State()
        {
            if (StateWords == null) StateWords = new List<string>
            { "лучше некуда",  "прекрастно", "замечательно", "паршиво",
            "супуер пупер", "чики пуки", "неполохо", "могло быть и хуже",
            "все норм", "как обычно", "отдыхаю по роботски", "чертовски хреново",
            "сгораю от голода", "спать хочу", "устал", "заболел немного",
            "полон сил и энергии", "я потолстел", "нужно подкачатся к лету",
            "как никогда лучше", "музыку слушаю", "отдыхаю"};

            return StateWords[ToChoose.Next(0, StateWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Отказы"
        /// </summary>
        public static string Reject()
        {
            if (RejectsWords == null) RejectsWords = new List<string>
            { "нет", "нетушки", "fuck you", "ни за что", "я не сделаю это",
            "никода", "а может ты свои просьбы при себе оставишь", "придется тебе отказать",
            "ЧТО? НЕТ!", "отрицательно вожу головой, как бот",
                "мой отказ однозначный и не подлежит пересмотру", };

            return RejectsWords[ToChoose.Next(0, RejectsWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Извинения"
        /// </summary>
        public static string Apologys()
        {
            if (ApologysWords == null) ApologysWords = new List<string>
            { "простите", "прошу прощения", "не судите строго", "извините",
            "глубоко извиняюсь", "I'm so sorry", "1000000 извинений",
            "мне дико стыдно", "я прошу прощения", "пардон"};

            return ApologysWords[ToChoose.Next(0, ApologysWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Вводные слова"
        /// </summary>
        public static string Input()
        {
            if (InputWords == null) InputWords = new List<string>
            { "мне кажется", "я думаю", "как мне кажется", "я считаю",
            "уверен", "без сомнений", "как по мне", "по моему мнению",
            "по моему", "что-то мне подсказывает", "если подумать", "очевидно",
            "размышления привели меня к тому что"};

            return InputWords[ToChoose.Next(0, InputWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Прощание"
        /// </summary>
        public static string Bye()
        {
            if (ByeWords == null) ByeWords = new List<string>
            { "всего хорошего", "всего доброго", "спокойной ночи", "досвидания",
            "до встречи", "до скорой встречи", "прощайте", "давай вали уже",
            "пока", "чао", "был рад с вами пообщаться", "жаль, что вы уходите", "проваливай"};

            Index = ToChoose.Next(0, ByeWords.Count);

            return (Index < 4) ? ByeWords[Index] + " " + ForWho()
                : ByeWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Ответы на благодарности"
        /// </summary>
        public static string Welcome()
        {
            if (WelcomeWords == null) WelcomeWords = new List<string>
            { "да не за что", "не за что", "пожалуйста", "на здоровье",
                "Разделяйте разные вопросы точками, знаками вопроса и знаками восклицания.\n" +
            "нет проблем", "да пустяки", "мне не сложно", "спасибо в карман не положешь",
            "без проблем", "обращайся", "рад помочь"};
                
            Index = ToChoose.Next(0, WelcomeWords.Count);

            return WelcomeWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Не понял"
        /// </summary>
        public static string What()
        {
            if (WhatWords == null) WhatWords = new List<string>
            { "что", "я не понял", "я ничего не понимаю", "мне непонятно",
            "не могу понять", "не могу разобрать", "плохо слышу", "не слышу, что",
            "как вы сказали", "что вы сказали", "не понимаю вашу писанину"};

            Index = ToChoose.Next(0, WhatWords.Count);

            return WhatWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Приблизительно"
        /// </summary>
        public static string Some()
        {
            if (SomeWords == null) SomeWords = new List<string>
            { "около",  "примерно", "приблизительно", "в районе",
            "где-то", "почти"};

            Index = ToChoose.Next(0, SomeWords.Count);

            return SomeWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Предоставления"
        /// </summary>
        public static string Give()
        {
            if (GiveWords == null) GiveWords = new List<string>
            { "вот", "прошу", "держи", "на", "подавись", "получай",
            "отдаю в твое пользование", "забирай", "возьми", "пользуйся",
            "это тебе", "это вам"};

            Index = ToChoose.Next(0, GiveWords.Count);

            return GiveWords[Index];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Кого?"
        /// </summary>
        public static string Who()
        {
            if (WhoWords == null) WhoWords = new List<string>
            { "тебя", "вас", ""};

            return WhoWords[ToChoose.Next(0, WhoWords.Count)];
        }

        /// <summary>
        /// Метод для выбора слов из набора "Кому?"
        /// </summary>
        public static string ForWho()
        {
            if (ForWhoWords == null) ForWhoWords = new List<string>
            { "тебе", "вам", ""};

            return ForWhoWords[ToChoose.Next(0, ForWhoWords.Count)];
        }
    }
}
