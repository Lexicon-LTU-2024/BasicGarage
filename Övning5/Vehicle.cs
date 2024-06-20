using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5
{
    public abstract class Vehicle: IVehicle
    {
        //private string RegNr;
        //protected string Color;
        //protected int Wheels;

        public string RegNr { get; private set; }
        public string Color { get; private set; }
        public int Wheels { get; set; }


        public Vehicle(string RegNr, string Color, int Wheels)
        {
            this.RegNr = RegNr;
            this.Color = Color;
            this.Wheels = Wheels;
        }
        public virtual string Stats()
        {
            return $"Type: {this.GetType().Name}, RegNr: {RegNr}, Wheels: {Wheels}, Color: {Color}";
        }
    }
}
