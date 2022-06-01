namespace kriostat.pl.DataBase
{
    public interface IBookRepository
    {
        void Add(string title, string author, string ISBN);
        void Update(Guid Id, string title, string author, string ISBN);

        void Delete(Guid Id);
        List<Book> LoadFromRepository();
    }
}
