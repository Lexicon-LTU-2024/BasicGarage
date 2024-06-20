using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5
{
    public class Car : Vehicle
    {
        double CylinderVolume;

        public override string Stats()
        {
            return base.Stats() + $", Cylinder Volym: {CylinderVolume}";
        }

        public Car(string RegNr, string Color, int Wheels, double cylinder) : base(RegNr, Color, Wheels)
        {
            CylinderVolume = cylinder;

        }
    }

    public class Airplane : Vehicle
    {
        int NrOfEngines;
        public override string Stats()
        {
            return base.Stats() + $", Number of Engines: {NrOfEngines}";
        }
        public Airplane(string RegNr, string Color, int Wheels, int engines) : base(RegNr, Color, Wheels)
        {
            NrOfEngines = engines;
        }
    }

    public class Motorcycle : Vehicle
    {
        String FuelType;
        public override string Stats()
        {
            return base.Stats() + $", Fuel: {FuelType}";
        }
        public Motorcycle(string RegNr, string Color, int Wheels, string fuel) : base(RegNr, Color, Wheels)
        {
            FuelType = fuel;
        }
    }

    public class Bus : Vehicle
    {
        int NrOfSeats; 
        public override string Stats()
        {
            return base.Stats() + $", Seats: {NrOfSeats}";
        }
        public Bus(string RegNr, string Color, int Wheels, int seats) : base(RegNr, Color, Wheels)
        {
            NrOfSeats = seats;
        }
    }
    public class Boat : Vehicle
    {
        private int length;
        public override string Stats()
        {
            return base.Stats() + $", Length: {length}";
        }
        public Boat(string RegNr, string Color, int Wheels, int length) : base(RegNr, Color, Wheels)
        {
            this.length = length;
        }
    }
}
