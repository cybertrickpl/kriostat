namespace kriostat.pl.DataBase
{
    [Serializable]

    public class Book
    {
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string ISBN { get; set; }

        public Book()
        {
            Title = "Diuna";
            Author = "Herbert";
            ISBN = "123456";
        }

    }
}
