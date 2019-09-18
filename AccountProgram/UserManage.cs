using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyan.User
{
    class UserManage
    {
        private static UserManage Main;

        private static object locker = new object();

        private UserManage()
        {

        }

        public static UserManage GetInstance()
        {
            if (Main == null)
            {
                lock (locker)
                {
                    if (Main == null)
                    {
                        Main = new UserManage();
                    }
                }
            }

            return Main;
        }

        private ConcurrentDictionary<int, User> AllUsers = new ConcurrentDictionary<int, User>();

        private int AccountLength = 10;

        public bool AddUser(int ID, string Name, int Money)
        {
            try
            {
                if (AllUsers.Count < AccountLength)
                {
                    return AllUsers.TryAdd(ID, new User(ID, Name, Money));
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool RemoveUser(int ID)
        {
            return AllUsers.TryRemove(ID, out _);
        }

        public bool ContainsKeyUser(int ID)
        {
            return AllUsers.ContainsKey(ID);
        }

        public User GetUser(int ID)
        {
            return ContainsKeyUser(ID) ? AllUsers[ID] : null;
        }

        public List<int> GetAllKeys()
        {
            return AllUsers.Keys.ToList();
        }

        public List<User> GetAllValues()
        {
            return AllUsers.Values.ToList();
        }

        public List<string> GetAllName()
        {
            return AllUsers.Select(t => t.Value.Name).ToList();
        }
    }
}
