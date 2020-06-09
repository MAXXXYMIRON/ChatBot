using System;

namespace Chat.Users
{
    public class SimpleUser : User
    {
        string surname;
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname
        {
            get => surname;
            set =>
                surname = (value.Length < 50) ? value : value.Substring(0, 49);
        }

        /// <summary>
        /// Кол-во лет.
        /// </summary>
        public string Old => (DateTime.Now - DateBorn).ToString();
        
        public SimpleUser(string name, string surname, Sex sex, DateTime dateBorn) : 
            base(name, sex, dateBorn)
        {
            Surname = surname;
        }
    }
}
