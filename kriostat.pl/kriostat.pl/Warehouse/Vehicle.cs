namespace kriostat.pl.Warehouse
{
    public abstract class Vehicle
    {
        public string Number { get; set; }
        public string Name { get; set; }

        public float Mass { get; set; }

        protected  readonly string _vehicleType;

        public string VehicleType { get { return _vehicleType; } }

        public Vehicle(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        public virtual string Info() 
        {
            return "";
        }

    }
}
