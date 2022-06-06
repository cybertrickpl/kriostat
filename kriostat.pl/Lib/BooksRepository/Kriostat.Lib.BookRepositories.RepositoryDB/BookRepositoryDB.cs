using Kriostat.Lib.BookRepositories.RepositoryDB.Entities;
using Kriostat.Lib.Common.Entities;
using Kriostat.Lib.Common.Interfaces;

namespace Kriostat.Lib.BookRepositories.RepositoryDB
{
    public class BookRepositoryDB : IBookRepository
    {
        private readonly MyContext _context;
        public BookRepositoryDB(MyContext context)
        {
            _context = context;

        }

        public void Add(string title, string author, string ISBN)
        {
            BookDB book = new BookDB() { Title = title, Author = author, ISBN = ISBN, Id = Guid.NewGuid().ToString(), ModifStamp = DateTime.Now };
            _context.Books.Add(book);
            _context.SaveChanges();

        }

        public void Edit(Guid id, string title, string author, string ISBN)
        {
            BookDB book = _context.Books.Where(x=>!x.DeleteStamp.HasValue).First(x=>x.Id == id.ToString().ToLower());
            if (book != null)
            {
                book.Title = title;
                book.Author = author;
                book.ISBN = ISBN;
                book.ModifStamp = DateTime.Now;
                _context.SaveChanges();
            }
        



        }

        public void Delete(Guid id)
        {
            BookDB book = _context.Books.Find(id.ToString().ToLower());
            if (book != null)
            {
                book.DeleteStamp = DateTime.Now;
                _context.SaveChanges();
            }


        }

        public List<Book> LoadFromRepository()
        {
            return _context.Books.Where(x=>!x.DeleteStamp.HasValue).OrderByDescending(x => x.ModifStamp).Select(x => new Book() { 
             Author = x.Author, Title = x.Title, ISBN = x.ISBN, Id = Guid.Parse(x.Id)}).ToList();
        }
        public int SaveToRepository(List<Book> list)
        {
            return 5;

        }

        public void Update(Guid Id, string title, string author, string ISBN)
        {
            throw new NotImplementedException();
        }
    }
}
