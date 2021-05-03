using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class Remote
    {
        private Drone drone;
        private double step = 0.1;
        private double remoteRange = 25.0;

        public Remote(Drone d)
        {
            drone = d;
        }

        public void TakeOff()
        {
            if(!drone.MotorOn) { 
                drone.MotorOn = true;
                drone.Height = 1.0;
            }
        }

        public void Land()
        {
            drone.Height = 0.0;
            drone.MotorOn = false;
        }

        public void MoveForward()
        {
            if (drone.MotorOn)
            {
                double tempLatitude = drone.Latitude;
                double tempLongitude = drone.Longitude;

                double radiaal = (Math.PI / 180) * drone.Rotation;
                drone.Latitude += Math.Cos(radiaal) * step;
                drone.Longitude += Math.Sin(radiaal) * step;

                if (getDistanceFromRemote() > remoteRange)
                {
                    drone.Latitude = tempLatitude;
                    drone.Longitude = tempLongitude;
                }
            }
        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }

        public void MoveBackwards()
        {

        }

        public double getDistanceFromRemote()
        {
            //enkel afstand in hoogte, moet iets zijn met vierkantswortel met latitute, longitude en height
            return drone.Height;
        }

        public void MoveUp()
        {
            if (drone.MotorOn)
            {
                double temp = drone.Height;
                drone.Height += step;

                if(getDistanceFromRemote()> remoteRange)
                {
                    drone.Height = temp;
                }
            }
        }

        public void MoveDown()
        {
            // do not move lower than 1 meter
        }

        public void Rotate(int graden)
        {
            if (drone.MotorOn)
            {
                drone.Rotation += graden;
            }
        }
    }
}
