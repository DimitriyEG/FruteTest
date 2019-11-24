using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruteTestLiblary.bl.Controller;
using FruteTestLiblary.bl.Model;

namespace FruteTest.cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("==================");
            Console.WriteLine("Dratute");
            Console.WriteLine("==================");
            Console.WriteLine("Enter you name pls");
            var name = Console.ReadLine();
           

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrenUser);
            if (userController.IsNewUser)
	        {
                Console.WriteLine("Hello. You - new user, pls, enter you params");
                Console.WriteLine("Enter you gender pls");
                var gender = Console.ReadLine();
                Console.WriteLine("Enter you date pls - (00.00.0000)");
                var dayBirdth = ParseDate();
                Console.WriteLine("Enter you weight pls");
                var weight = ParseDouble("weight = ");
                userController.SetNewUserParam(gender, dayBirdth, weight);
	        }
            Console.WriteLine(userController.CurrenUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.Write("E - enter eating");
            Console.WriteLine("");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EatingEnter();
                eatingController.AddFood(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t product: {item.Key}, value - {item.Value} g.");
                }
                Console.ReadLine();
            }


        }

        private static (Food Food, double Weight) EatingEnter()
        {
            Console.Write("Enter food name: ");
            var foodName = Console.ReadLine();
            var calories = ParseDouble("product energy");
            var proteins = ParseDouble("product proteins");
            var fats = ParseDouble("product fats");
            var carbohydrates = ParseDouble("product carbons");
            var weight = ParseDouble("product weigth ");
            var product = new Food(foodName, calories, proteins, fats, carbohydrates);
            return (Food: product, Weight: weight);

        }

        private static double ParseDouble (string name) 
        {
            while(true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                    {
                    return value;
                    }
                else 
                {
                    Console.WriteLine($"Invaild format");
                }

            }
        }
        private static DateTime ParseDate () 
        {
            DateTime dayBirdth; 
            while(true)
            {
                Console.Write($"Enter date");
                if (DateTime.TryParse(Console.ReadLine(), out  dayBirdth))
                    {
                    break;
                    }
                else 
                {
                    Console.WriteLine($"Invaild format");
                }

            }
            return dayBirdth;
        }
    }
}
