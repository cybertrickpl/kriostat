using System.ComponentModel.DataAnnotations;

namespace kriostat.pl.Models.Report
{
    public class IndexViewModel
    {

        public double? A { get; set; }

        public double? B { get; set; }

        public double? C { get; set; }

        public int Year { get; set; }
        public string? FirstName { get; set; }

        public bool IsJacek
        {
            get
            {
                if (FirstName != null)
                {
                    if (FirstName.ToUpper() == "JACEK") { return true; }
                }

                return false;
            }
        }

        public double SqrtYear
        {
            get
            {
                return Math.Sqrt(Year);
            }
        }

        public string ZerosMessage()
        {
            
                if (!A.HasValue)
                {
                    return "Uzupełnij A";
                }

                return "";

            
        }
    }
}
