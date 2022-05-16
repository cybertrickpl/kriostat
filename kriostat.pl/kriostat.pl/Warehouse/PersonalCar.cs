namespace kriostat.pl.Warehouse
{
    public class PersonalCar: Vehicle
    {
        public int SeatNumber { get; set; }

        public PersonalCar() : base("pasażerski")
        {

        }

        public override string Info()
        {
            return $"Mam {SeatNumber} miejsc";
        }
    }


}
