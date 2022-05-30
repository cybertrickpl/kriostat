﻿namespace kriostat.pl.DataBase
{
    [Serializable]

    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string ISBN { get; set; }

        public Book()
        {
            Title = "Gone with the wind";
            Author = "Smith";
            ISBN = "123456";
        }

    }
}
