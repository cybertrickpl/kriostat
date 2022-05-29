using kriostat.pl.DataBase;
using kriostat.pl.Warehouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;
using System.Linq;

namespace kriostat.pl.Pages
{
    public class IndexModelViewModel
    {
        [BindProperty]
        public string BookTitle { get; set; }

        [BindProperty]
        public string BookAuthor { get; set; }

        [BindProperty]
        public string BookISBN { get; set; }


        public List<Book> ListofBooks { get; set; }
    }


    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int Count { get; set; }

        public List<Vehicle> ListofVehicles { get; set; }


        [BindProperty]
        public IndexModelViewModel IndexModelViewModel { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;




            //ListofVehicles = new List<Vehicle>();
            //ListofVehicles.Add(new Military() {Name = "Fiat", Number = "1", Mass = 500});
            //ListofVehicles.Add(new Truck() { Name = "Skoda", Number = "3" , Mass = 700});
            //ListofVehicles.Add(new Truck() { Name = "Porsche", Number = "100", Mass = 1000 });
            //ListofVehicles.Add(new PersonalCar() { Name = "Mercedes", Number = "13", Mass = 800, SeatNumber = 5 });
        }

        //public void OnGet()
        //{
        //    int? count = this.HttpContext.Session.GetInt32("counter");

        //    if (count == null) { count = 0; }
        //    count++;
        //    this.HttpContext.Session.SetInt32("counter", count.Value);
        //    Count = count.Value;

        //}

        public List<Book> LoadFromRepository()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer =
                   new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));

                string? path = System.IO.Path.Combine("c:\\Test", "Repository.txt");

                MemoryStream memoryStream = new MemoryStream();

                var file = System.IO.File.ReadAllBytes(path);

                memoryStream.Write(file, 0, file.Length);

                memoryStream.Position = 0;

                var FileContent = writer.Deserialize(memoryStream);

                return (List<Book>)FileContent;

            }
            catch (Exception ex)
            { }
            return new List<Book>();
        }
        public int SaveToRepository()
        {
            //List<Book> books = LoadFromRepository();
            //books.Add(book);


            System.Xml.Serialization.XmlSerializer writer =
                   new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));

            string? path = System.IO.Path.Combine("c:\\Test", "Repository.txt");

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this.IndexModelViewModel.ListofBooks);

            file.Close();

            return 0;

        }

        public string EditBook(Book book)
        {

            return book.Author;
        }


        public IActionResult OnGet(Guid? deleteRow, Guid? editRow)
        {
            IndexModelViewModel = new IndexModelViewModel();
            IndexModelViewModel.ListofBooks = LoadFromRepository();
            if (deleteRow.HasValue)
            {
                IndexModelViewModel.ListofBooks.RemoveAll(p => p.Id == deleteRow.Value);
                SaveToRepository();
            }

            if (editRow.HasValue)
            {
                Book BookToEdit = new Book();
                BookToEdit = IndexModelViewModel.ListofBooks.Find(p => p.Id==editRow.Value);
                Console.WriteLine(EditBook(BookToEdit));
            }
            return Page();
        }



        public IActionResult OnPost()
        {

            IndexModelViewModel.ListofBooks = LoadFromRepository();
            Book book = new Book()
            {
                Title = IndexModelViewModel.BookTitle,
                Author = IndexModelViewModel.BookAuthor,
                ISBN = IndexModelViewModel.BookISBN,
                Id = Guid.NewGuid()
            };

            this.IndexModelViewModel.ListofBooks.Add(book);
            SaveToRepository();
            return Page();
        }

    }
}