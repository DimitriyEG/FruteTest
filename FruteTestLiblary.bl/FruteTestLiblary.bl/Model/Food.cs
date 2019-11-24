using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruteTestLiblary.bl.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; set; }
        /// <summary>
        /// Белки
        /// </summary>
        public  double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Каллории
        /// </summary>
        public double Calories { get; }

        //private double CaloriesOneGramm { get { return Calories / 100.0; } }
        //private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        //private double FatsOneGramm { get { return Fats / 100.0; } }
        //private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        public Food (string name) : this(name, 0, 0, 0, 0)       {        }
        /// <summary>
        /// Конструктор продукта
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="calories">Каллорийность</param>
        /// <param name="proteins">Белки</param>
        /// <param name="fats">Жиры</param>
        /// <param name="carbohydrates">Углеводы</param>
        public Food(string name, double calories,  double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
