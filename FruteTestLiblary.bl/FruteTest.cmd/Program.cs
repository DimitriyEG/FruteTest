using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruteTestLiblary.bl.Controller;

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

       
            //Console.WriteLine("Ваши параметры записаны \nname - {0};\ngender - {1};\ndata - {2};\nweight - {3}kg;", name, gender, dayBirdth, weight);
            Console.ReadLine();


        }
        private static double ParseDouble (string name) 
        {
            while(true)
            {
                Console.Write($"Enter {name}:");
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
