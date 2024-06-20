namespace Övning5
{
    public interface IVehicle
    {
        public string RegNr { get; }
        public string Color { get; }
        public int Wheels { get; set; }

        public string Stats();
    }
}