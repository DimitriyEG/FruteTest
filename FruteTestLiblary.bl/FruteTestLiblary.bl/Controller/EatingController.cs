using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FruteTestLiblary.bl.Model;

namespace FruteTestLiblary.bl.Controller
{
    public class EatingController : BaseController
    {
        private User User { get; }
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController (User user)
        {
            User = user ?? throw new ArgumentNullException("", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public bool AddFood(string foodName, double weight)
        {
            var food = Foods.SingleOrDefault(f => f.Name == foodName);
            if(food != null)
            {
                Eating.Add(food, weight);
                Save();
                return true;
            }
            return false;
        }
        public void AddFood(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }

        }

        private Eating GetEating()
        {
            return Load<Eating>("eating.txt") ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        { 
            return Load<List<Food>>("eating.txt") ?? new List<Food>();
        }

        public void Save()
        {
            Save("food.txt", Foods);
            Save("eating.txt", Eating);
        }
    }
}
