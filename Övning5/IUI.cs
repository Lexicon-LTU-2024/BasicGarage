namespace Övning5
{
    internal interface IUI
    {
        public abstract string GetInput();

        public int GetNumber();

        public ConsoleKey GetKey();

        public void Output(string input);

        public void PrintList(List<IVehicle> list);

        public void PrintVehicle(IVehicle vehicle);

        public String GetVehicleType();
    }
}