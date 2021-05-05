using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3
{
    class CarRepository
    {
        private UserContext context = new UserContext();

        //create
        public void AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        //read
        public List<Car> GetAllCars()
        {
            return context.Cars.ToList();
        }

        //update
        public void UpdateCar(Car car)
        {
            // hier is niets nodig omdat het object reeds gelinkt is met de data
            context.SaveChanges();
        }

        //delete
        public void DeleteCar(Car car)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
        }
    }
}
