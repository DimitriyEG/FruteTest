using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruteTestLiblary.bl.Model
{
    public class Gender
    {
        public string Name { get; }

        Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("`Пол` не может быть пустым");
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
