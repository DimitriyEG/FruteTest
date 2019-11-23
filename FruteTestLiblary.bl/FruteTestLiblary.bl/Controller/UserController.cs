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
        
        public List<User> Users { get; }
        public User CurrenUser { get; }
        public bool IsNewUser { get;} = false;
        public UserController(string usName)
        {
            if (string.IsNullOrWhiteSpace(usName))
            {
                throw new ArgumentNullException("");
            }
            Users = GetUserData();
	        CurrenUser = Users.SingleOrDefault(u => u.Name == usName);

            if(CurrenUser == null)
            {
                CurrenUser = new User(usName);
                IsNewUser = true;
                Users.Add(CurrenUser);
                Save();
            }

        }
        public void SetNewUserParam (string genderName, DateTime dayOfBirth, double weight = 20)
        {
            CurrenUser.Gender = new Gender(genderName);
            CurrenUser.DayOfBirth = dayOfBirth;
            CurrenUser.Weight = weight;
            Save();
        }

        private List<User> GetUserData ()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("userdata.txt", FileMode.OpenOrCreate))
            {
                if(fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                   return users;
                }
                else
                {
                    //throw new FileLoadException();
                    return new List<User>();
                }
            }
            }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("userdata.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        
        
    }
}
