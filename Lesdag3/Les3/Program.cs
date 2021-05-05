using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //DoDbContextInserting();
            //DoDbContextManipulation();
            UseUserRepository();

            // Direct control of database
            /*int score = GetScoreOfStudent("Bart'; Drop Table Student; --");
            Console.WriteLine(score);*/
            //Console.ReadLine();
        }

        public static void UseUserRepository()
        {
            UserRepository usersRepository = new UserRepository();

            List<User> users = usersRepository.GetAllUsersWithCars();

            Console.WriteLine(users.First().Cars.Count());
            Console.ReadLine();

        }

        public static void DoDbContextManipulation()
        {
            UserContext context = new UserContext();

            User user2 = context.Users.First(user => user.FirstName == "Lisa");
            user2.FirstName = "Marge";
            //context.Users.Remove(user2);

            //context.Users.Select(user => user.FirstName);

            context.SaveChanges();

        }

        public static void DoDbContextInserting()
        {
            UserContext context = new UserContext();

            //maakt de users aan
            User user = new User("Bart", "Simpsons");
            User user2 = new User("Lisa", "Simpsons");
            User user3 = new User("Maggy", "Simpons");

            //voegt users toe aan de lijst van users
            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);

            Car car = new Car("BMW");
            Car car2 = new Car("Audi");
            car2.Model = "A1";

            context.Cars.Add(car);
            context.Cars.Add(car2);

            //user heeft beide auto's, user2 heeft enkel auto2
            user.Cars.Add(car);
            user.Cars.Add(car2);
            car.Users.Add(user);
            car2.Users.Add(user);
            user2.Cars.Add(car2);
            car2.Users.Add(user2);

            //stuurt alles naar de databank
            context.SaveChanges();
        }

        public static int GetScoreOfStudent(string naam) 
        {
            int result = -1;
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=studenten;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Student where Naam='" + naam + "'", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result = (int)reader[2];
            }

            reader.Close();
            conn.Close();

            return result;
        }
    }
}
