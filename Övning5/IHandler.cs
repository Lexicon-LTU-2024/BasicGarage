namespace Övning5
{
    internal interface IHandler
    {
        //private Garage<IVehicle> thisGarage;

        //private IQueryable<IVehicle> query;
        public void InitGarage();
        public List<IVehicle> GetGarage();

        public IVehicle? GetFromRegNr(string regNr);

        public void AddVehicle(IVehicle vehicle);

        public bool RemoveVehicle(string regNr);

        public int NrOfType(string type);

        public bool IsFull();

        public void InitFilter();
        public void Filter(string typeQ, string typeS, int typeI);

        public List<IVehicle> PrintFilter();

    }
}
