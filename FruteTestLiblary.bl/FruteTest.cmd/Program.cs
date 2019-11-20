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
            Console.WriteLine("Enter you gender pls");
            var gender = Console.ReadLine();
            Console.WriteLine("Enter you date pls - (00.00.0000)");
            var dayBirdth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter you weight pls");
            var weight = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, dayBirdth, weight);
            userController.Save();
            Console.WriteLine("Ваши параметры записаны \nname - {0};\ngender - {1};\n data - {2};\nweight - {3}kg;", name, gender, dayBirdth, weight);
            Console.ReadLine();


        }
    }
}
