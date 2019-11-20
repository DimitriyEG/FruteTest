using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruteTestLiblary.bl.Model;

namespace FruteTestLiblary.bl.Controller
{
    public class UserController
    {
        
        public User User { get; }
        public UserController(string name, string genderType, DateTime birthDay, double weight)
        {
            var gender = new Gender(genderType);
            User = new User(name, gender, birthDay, weight);

           // User = user ?? throw new ArgumentNullException("Пользователь не может быть равен null", nameof(user));
        }
 
        
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("userdata.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("userdata.txt", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    return user;
                }
                else
                {
                    throw new FileLoadException();
                }
            }
        }
    }
}
