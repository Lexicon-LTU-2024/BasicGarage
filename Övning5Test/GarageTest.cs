using Microsoft.VisualStudio.TestTools.UnitTesting;
using Övning5;

namespace Övning5Test
{
    [TestClass]
    public class GarageTest
    {

        [TestMethod]
        public void IsFull_False_WhenEmpty()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Add(new Car("DEF456", "White", 4, 1.64));
            //--Act
            bool full = garage.IsFull;
            //--Assert
            Assert.IsFalse(full);
        }

        [TestMethod]
        public void IsFull_True_WhenFull()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Add(new Car("DEF456", "White", 4, 1.64));
            garage.Add(new Car("GHI789", "Black", 6, 24));
            garage.Add(new Car("JKL101", "Blue", 4, 19));
            //--Act
            bool full = garage.IsFull;
            //--Assert
            Assert.IsTrue(full);
        }

        [TestMethod]
        public void Add_WhenGarageFull_ReturnFalse()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Add(new Car("DEF456", "White", 4, 1.64));
            garage.Add(new Car("GHI789", "Black", 6, 24));
            garage.Add(new Car("JKL101", "Blue", 4, 19));
            //--Act
            bool result = garage.Add(new Car("AB2123", "Red", 4, 15));
            //--Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void Add_EmptyGarage_ReturnTrue()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            var car = new Car("AB2123", "Red", 4, 15);
            //--Act
            bool result = garage.Add(car);
            //--Assert
            Assert.IsTrue(result);
            Assert.AreEqual(garage[0], car);

        }

        [TestMethod]
        public void Unpark_EmptyGarage_ReturnFalse()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            //--Act
            bool result = garage.Unpark("ABC123");
            //--Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void Unpark_RegNrNotInGarage_ReturnFalse()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Add(new Car("DEF456", "White", 4, 1.64));
            //--Act
            bool result = garage.Unpark("ABC123");
            //--Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void Unpark_VehicleFromGarage_ReturnTrue()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Add(new Car("ABC123", "White", 4, 1.64));
            //--Act
            bool result = garage.Unpark("ABC123");
            //--Assert
            Assert.IsTrue(result);
            Assert.AreEqual(garage[0], null);
        }

        [TestMethod]
        public void Unpark_VehicleFromGarageWithNoCapitals_ReturnTrue()
        {
            //--Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Add(new Car("abc123", "White", 4, 1.64));
            //--Act
            bool result = garage.Unpark("ABC123");
            //--Assert
            Assert.IsTrue(result);
            Assert.AreEqual(garage[0], null);

        }
    }

}