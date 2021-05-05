using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmi_calculator
{
    class UserRepository
    {
        private DatabaseContext context = new DatabaseContext();

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }


    }
}
