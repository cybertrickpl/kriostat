using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kriostat.pl.Pages
{
    public class GraphModelViewModel
    {
        [BindProperty]
        public double? A { get; set; }

        [BindProperty]
        public double? B { get; set; }

        [BindProperty]
        public double? C { get; set; }

        public string? PESEL { get; set; }

        public string CheckPESEL()
        {

            if (PESEL == null)
            {
                return "Wprowadź PESEL";
            }

            else if (PESEL.Length != 11)
            {
                return "Niepoprawna długość";
            }

            else
            {
                try
                {
                    int Sum = 0;

                    int[] Wagi = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

                    string[] NumbersChar = PESEL.ToCharArray().Select(c => c.ToString()).ToArray();

                    int[] Numbers = Array.ConvertAll(NumbersChar, s => int.Parse(s));


                    for (int i = 0; i < Wagi.Length; i++)
                    {
                        Sum += Wagi[i] * Numbers[i];

                    }

                    int CyfraKontrolna = 10 - (Sum % 10);


                    if (CyfraKontrolna == 10)
                    {
                        CyfraKontrolna = 0;
                    }

                    if (CyfraKontrolna == Numbers[10])
                    { return "PESEL poprawny"; }

                    else
                    { return "PESEL niepoprawny"; }

                }

                catch
                {
                    return "bląd formatu";
                }

            }


            return "";
        }

        public string ZerosMessage()
        {

            if (!A.HasValue || !B.HasValue || !C.HasValue)
            {
                return "Uzupełnij wszystkie parametry";
            }

            else
            {
                double Delta = Math.Pow(B.Value, 2) - 4 * A.Value * C.Value;

                if (Delta >= 0)
                {
                    double zero1 = ((-1) * B.Value - Math.Pow(Delta, 0.5)) / (2 * A.Value);
                    double zero2 = ((-1) * B.Value + Math.Pow(Delta, 0.5)) / (2 * A.Value);
                    return zero1.ToString() + ", " + zero2.ToString();
                }

                else
                {
                    return "brak miejsc zerowych";
                }

            }

            return "";



        }



        public List<xy> GetData()
        {
            List<xy> data = new List<xy>();
            if (A.HasValue && B.HasValue && C.HasValue)
            {
                for (double x = -5; x < 5; x += 0.1)
                {
                    double y = A.Value * Math.Pow(x, 2) + B.Value * x + C.Value;
                    data.Add(new xy { X = x, Y = y });

                }
            }
            return data;

        }

    }


    public class xy
    {
        public double X { get; set; }
        public double Y { get; set; }

    }


    public class GraphModel : PageModel
    {
        private readonly ILogger<GraphModel> _logger;
        public string? A { get; set; }

        [BindProperty]
        public GraphModelViewModel GraphModelViewModel { get; set; }



        public GraphModel(ILogger<GraphModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(GraphModelViewModel graphModel)
        {


            return Page();
        }
    }
}