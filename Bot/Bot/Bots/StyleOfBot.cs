using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace Chat
{
    /// <summary>
    /// Абстрактый класс, с которым работают классы Bot, Questions и Answers. 
    /// Предоставляет им наборы вопросов и ответов, соответствующих стилю бота,
    /// т.е. класс - наследник этого класса, поддерживает определенный стиль. 
    /// Для этого он определяет набор регулярных выражений для вопроссов и 
    /// соответствующие методы для ответа на эти вопросы, а также набор 
    /// дополнительных слов в ответе и методы выбора этих слов.
    /// </summary>
    public abstract class StyleOfBot
    {
        /// <summary>
        /// Имя файла со справкой, содержащей описание бота.
        /// </summary>
        readonly string Reference;



        /// <summary>
        /// Ключ в словаре - регулярное выражение, которое соответствует
        /// определенному вопросу.
        /// Значение в словаре - это структура, содержащая данные 
        /// для ответа на вопрос.
        /// </summary>
        public Dictionary<Regex, PackForAnswer> Pack { get; protected set; }

        /// <summary>
        /// Поле для бота с данными о пользователе. 
        /// </summary>
        public User UserOfBot { get; set; }

        /// <summary>
        /// Возвращает объект для считывания информации о боте.
        /// </summary>
        public StreamReader Help() => new StreamReader(Reference);

        /// <summary>
        /// Освобождение ресурсов бота.
        /// </summary>
        public virtual void Dispose()
        {
            Pack.Clear();
            UserOfBot = null;
        }



        /// <summary>
        /// Поле, которое вернет ключ в словаре, по которому составится ответ
        /// на некорректно поставленный вопрос.
        /// </summary>
        internal abstract Regex NotUnderstand { get; }



        /// <summary>
        /// Поле для записи информации о боте. 
        /// </summary>
        protected StreamWriter HelpWrite;

        /// <summary>
        /// Наследник передает в конструктор название файла со справкой о себе. 
        /// </summary>
        protected StyleOfBot(string reference)
        {
            Reference = reference + ".txt";
            HelpWrite = new StreamWriter(Reference);
            MakeHelp();
            HelpWrite.Close();
        }

        /// <summary>
        /// Предполагается переопределение метода в наследнике,
        /// т.е. запись справки соответствующей наследнику.
        /// </summary>
        protected virtual void MakeHelp()
        {
            HelpWrite.WriteLine("Простите, справка на данного бота пока отсутствует.");
        }

        /// <summary>
        /// Не всегда требуется отвечать на сообщение пользователя. 
        /// Поэтому для всех наследников определен метод возврата пустой строки. 
        /// </summary>
        protected string Void(string arg)
        {
            return "";
        }
    }
}
