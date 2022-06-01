﻿using kriostat.pl.DataBase;
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
        
        private readonly IBookRepository _bookRepository;
        public int Count { get; set; }

        public List<Vehicle> ListofVehicles { get; set; }

        public int IndexToEdit { get; set; } = -1;


        [BindProperty]
        public IndexModelViewModel IndexModelViewModel { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _bookRepository = new BookRepositoryFS();



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

                string? path = System.IO.Path.Combine("c:\\Test", "Repository.xml");

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

            string? path = System.IO.Path.Combine("c:\\Test", "Repository.xml");

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this.IndexModelViewModel.ListofBooks);

            file.Close();

            return 0;

        }




        public IActionResult OnGet(Guid? deleteRow, Guid? editRow)
        {
            IndexModelViewModel = new IndexModelViewModel();
            IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();


            if (deleteRow.HasValue)
            {
                _bookRepository.Delete(deleteRow.Value);
                IndexModelViewModel.ListofBooks= _bookRepository.LoadFromRepository();
            }

            if (editRow.HasValue)
            {

                var index = IndexModelViewModel.ListofBooks.FirstOrDefault(p => p.Id == editRow.Value);
                IndexModelViewModel.BookAuthor = index.Author;
               
            }

            return Page();
        }



        public int Add()
        {
            _bookRepository.Add(IndexModelViewModel.BookTitle, IndexModelViewModel.BookAuthor, IndexModelViewModel.BookISBN);
            IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();


            return 0;
        }

        public int Edit(int index)
        {
                        IndexModelViewModel.ListofBooks = LoadFromRepository();
                        string Title = IndexModelViewModel.BookTitle;
                        string Author = IndexModelViewModel.BookAuthor;
                        string ISBN = IndexModelViewModel.BookISBN;

                        Book EditedBook = this.IndexModelViewModel.ListofBooks.ElementAt(index);

                        EditedBook.Title = Title;
                        EditedBook.Author = Author;
                        EditedBook.ISBN = ISBN;                        

                        this.IndexModelViewModel.ListofBooks[index] = EditedBook;
                        
                        SaveToRepository();
            return 0;
        }

        public void ClickAdd(object sender, EventArgs e)
        {
            
        }


        public IActionResult OnPost(string button, Guid? deleteRow, Guid? editRow)
        {
            
            int index = Int32.Parse(button);

            if (index < 0) Add();

            else Edit(index);

            return Page();
        }

        //public IActionResult OnPost(string button)
        //{
        //    IndexModelViewModel.ListofBooks = LoadFromRepository();

        //    switch (button)
        //    {
        //        case "Add":

        //            Book book = new Book()
        //            {
        //                Title = IndexModelViewModel.BookTitle,
        //                Author = IndexModelViewModel.BookAuthor,
        //                ISBN = IndexModelViewModel.BookISBN,
        //                Id = Guid.NewGuid()
        //            };

        //            this.IndexModelViewModel.ListofBooks.Add(book);
        //            SaveToRepository();
        //            break;


        //        case "Edit":

        //            int index = 0;

        //            string Title = IndexModelViewModel.BookTitle;
        //            string Author = IndexModelViewModel.BookAuthor;
        //            string ISBN = IndexModelViewModel.BookISBN;

        //            Book bookToEdit = this.IndexModelViewModel.ListofBooks.ElementAt(index);

        //            bookToEdit.Title = Title;
        //            bookToEdit.Author = Author;
        //            bookToEdit.ISBN = ISBN;

        //            this.IndexModelViewModel.ListofBooks.Insert(index, bookToEdit);
        //            SaveToRepository();
        //            break;
        //    }

        //    return Page();

        //}

    }
}