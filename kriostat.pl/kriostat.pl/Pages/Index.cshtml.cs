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

        public Guid? IdToEdit { get; set; } = null;


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

             



        public void Add()
        {
            IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();
            _bookRepository.Add(IndexModelViewModel.BookTitle, IndexModelViewModel.BookAuthor, IndexModelViewModel.BookISBN);
            IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();

        }

        public void Edit(Guid editRow)
        {
             IdToEdit = null;

             IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();
             _bookRepository.Edit(editRow, IndexModelViewModel.BookTitle, IndexModelViewModel.BookAuthor, IndexModelViewModel.BookISBN);
             IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();

        }

        public IActionResult OnGet(Guid? deleteRow, Guid? editRow)
        {
            IndexModelViewModel = new IndexModelViewModel();
            IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();
           

            if (deleteRow.HasValue)
            {
                _bookRepository.Delete(deleteRow.Value);
                IndexModelViewModel.ListofBooks = _bookRepository.LoadFromRepository();
            }

            if (editRow.HasValue)
            {
               
                var ItemToEdit = IndexModelViewModel.ListofBooks.FirstOrDefault(p => p.Id == editRow.Value);
                IndexModelViewModel.BookTitle = ItemToEdit.Title;
                IndexModelViewModel.BookAuthor = ItemToEdit.Author;
                IndexModelViewModel.BookISBN = ItemToEdit.ISBN;
                
                IdToEdit = ItemToEdit.Id;
                                                           
            }

            return Page();
        }

        public IActionResult OnPost(Guid? editRow)
        {                        
            if (editRow.HasValue) Edit(editRow.Value);
            else Add();

            return Page();
        }

       
    }
}