using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyan.User
{
    class User
    {
        public int ID { get; }
        public string Name { get; }
        public int Money { get; private set; }

        public User(int ID,string Name,int Money)
        {
            this.ID = ID;
            this.Name = Name;
            this.Money = Money;
        }
    }
}
