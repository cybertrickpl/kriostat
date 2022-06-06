using Kriostat.Lib.Common.Entities;

namespace Kriostat.Lib.Common.Interfaces
{
    public interface IBookRepository
    {
        void Add(string title, string author, string ISBN);
       
        
        void Delete(Guid Id);
       
        List<Book> LoadFromRepository();
       
        int SaveToRepository(List<Book> list);

        void Edit(Guid id, string title, string author, string ISBN);
    }
}
