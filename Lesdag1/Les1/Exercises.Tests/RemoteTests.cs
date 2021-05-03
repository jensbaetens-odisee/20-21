using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Exercises.Tests
{

    [TestFixture]
    class RemoteTests
    {
        private Remote remote;
        private Drone drone;

        [SetUp]
        public void SetUp()
        {
            drone = new Drone();
            remote = new Remote(drone);
        }

        [Test]
        public void TakeOff_StartingOnGround_ThenTakingOff()
        {
            //Arrange

            //Act
            remote.TakeOff();

            //Assert
            Assert.That(drone.MotorOn, Is.True);
            Assert.That(drone.Height, Is.EqualTo(1.0));
        }

        [Test]
        public void TakeOff_DroneIsFlying_ThenNotTakingOff()
        {
            //Arrange
            //remote.TakeOff();
            drone.MotorOn = true;
            drone.Height = 2.0;

            //Act
            remote.TakeOff();

            //Assert
            Assert.That(drone.MotorOn, Is.True);
            Assert.That(drone.Height, Is.EqualTo(2.0));
        }

        [Test]
        public void MoveUp_DroneIsNotFlying_ThenNotMovingUp()
        {
            //Arrange
            
            //Act
            remote.MoveUp();

            //Assert
            Assert.That(drone.MotorOn, Is.False);
            Assert.That(drone.Height, Is.EqualTo(0.0));
        }


        [Test]
        public void MoveUp_DroneIsFlyingWithinRange_ThenMovingUp()
        {
            //Arrange
            remote.TakeOff();

            //Act
            remote.MoveUp();

            //Assert
            Assert.That(drone.MotorOn, Is.True);
            Assert.That(drone.Height, Is.EqualTo(1.1));
        }

        [Test]
        public void MoveUp_DroneIsMovingOutsideRange_ThenNotMovingUp()
        {
            //Arrange
            remote.TakeOff();
            drone.Height = 25.0;

            //Act
            remote.MoveUp();

            //Assert
            Assert.That(drone.MotorOn, Is.True);
            Assert.That(drone.Height, Is.EqualTo(25.0));
        }

        [Test]
        public void MoveForward_DroneIsFlyingAndNotRotatedWithinRange_ThenMovingForward()
        {
            //Arrange
            remote.TakeOff();

            //Act
            remote.MoveForward();

            //Assert
            Assert.That(drone.MotorOn, Is.True);
            Assert.That(drone.Height, Is.EqualTo(1.0));
            Assert.That(drone.Latitude, Is.EqualTo(0.1));
            Assert.That(drone.Longitude, Is.EqualTo(0.0));
        }


        [TestCase(45, 10.0, 5.0)]
        public void MoveForward_DroneIsFlyingAndRotated45DegreesWithinRange_ThenMovingForward(int degrees, double lat, double longi)
        {
            //Arrange
            double radiaal = (Math.PI / 180) * degrees;
            remote.TakeOff();
            remote.Rotate(degrees);

            //Act
            remote.MoveForward();

            //Assert
            //Dit gaat enkel werken als latitute en longitude 0, 0 zijn bij start
            double expectedStepLat = Math.Cos(radiaal) * 0.1;
            double expectedStepLong = Math.Sin(radiaal) * 0.1;

            Assert.That(drone.MotorOn, Is.True);
            Assert.That(drone.Height, Is.EqualTo(1.0));
            Assert.That(drone.Latitude, Is.EqualTo(expectedStepLat));
            Assert.That(drone.Longitude, Is.EqualTo(expectedStepLong));
        }


    }
}
