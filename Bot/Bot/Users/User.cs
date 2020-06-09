using System;


namespace Chat
{
    /// <summary>
    /// Перечисление для указания пола пользователя.
    /// </summary>
    public enum Sex { Male, Female }

    /// <summary>
    /// Базовые данные о пользователе. 
    /// </summary>
    public class User
    {
        string name;
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => name;
            set =>
                name = (value.Length < 50) ? value : value.Substring(0, 49);
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateBorn { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public readonly Sex Sex;

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        public User(string name, Sex sex, DateTime dateBorn)
        {
            Name = name;
            Sex = sex;
            DateBorn = dateBorn;
        }
    }
}
