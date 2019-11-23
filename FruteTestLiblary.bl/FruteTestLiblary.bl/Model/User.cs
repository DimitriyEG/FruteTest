using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruteTestLiblary.bl.Model
{
    [Serializable]
    public class User
    {
        public string Name {get; }
        public Gender Gender{ get; set;}
        public DateTime DayOfBirth { get; set; }
        
        public int Age {get{return ((DateTime.Now.Year - DayOfBirth.Year) );}} 

        public double Weight { get; set; }
        
        /// <summary>
        /// Конструктор нового пользователя
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="gender">Пол пользователя</param>
        /// <param name="daybirth">Дата рождения</param>
        /// <param name="weight">Вес, для красоты</param>
        public User(string name, Gender gender, DateTime daybirth, double weight)
        {
            #region Data check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.");
            } 
            if(gender== null)
            {
                throw new ArgumentNullException("`Пол` не может быть пустым.", nameof(gender));
            }
            if (daybirth < DateTime.Parse("01.01.1901") || daybirth > DateTime.Now )
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(daybirth));
            }
            if (weight <= 20)
            {
                throw new ArgumentException("Вес не может быть меньше 20кг.", nameof(weight));
            }
            #endregion
            Name = name;
            Gender = gender;
            DayOfBirth = daybirth;
            Weight = weight;
        }

         public User(string name)
        {
            
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.");
            } 
            Name = name;
         }

        public override string ToString()
        {
            return Name + " " + Age + " " + Gender.ToString();
        }
    }
}
