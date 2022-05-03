using System.ComponentModel.DataAnnotations;

namespace kriostat.pl.Models.Report
{
    public class IndexViewModel
    {
        [Required] 
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        [Required]
        public string C { get; set; }

        public int Year { get; set; }
        public string FirstName { get; set; }

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
    }
}
