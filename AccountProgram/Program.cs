using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyan.User;

namespace AccountProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManage T = UserManage.GetInstance();

            Console.WriteLine(T.AddUser(1, "Hyan", 10000));

            Console.WriteLine(T.AddUser(2, "HH", 5000));

            Console.ReadKey();
        }
    }
}
