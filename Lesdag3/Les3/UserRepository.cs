using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;           //Dit toevoegen voor de include
using System.Threading.Tasks;

namespace Les3
{
    class UserRepository
    {
        private UserContext context = new UserContext();

        //create
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        //read
        //list of cars are not filled in with this function
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public List<User> GetAllUsersWithCars()
        {
            return context.Users.Include(user => user.Cars).ToList();
        }

        //update
        public void UpdateUser(User user)
        {
            // hier is niets nodig omdat het object reeds gelinkt is met de data
            context.SaveChanges();
        }

        //delete
        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
