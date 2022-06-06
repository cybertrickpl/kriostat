using Kriostat.Lib.Common.Entities;
using Kriostat.Lib.Common.Interfaces;

namespace Kriostat.Lib.BooksRepository.Fake
{
    public class BookRepositoryFake2 : IBookRepository
    {
        public void Add(string title, string author, string ISBN)
        {


        }

        public void Edit(Guid id, string title, string author, string ISBN)
        {

            

        }

        public void Delete(Guid Id)
        {
            

        }

        public List<Book> LoadFromRepository()
        {
            return new List<Book> {
                new Book() {
                    Title = "Heban",
                    Author = "Kapuscinski",
                    ISBN = "123",
                    Id=Guid.NewGuid()
                },
                new Book() {
                    Title = "Avatar",
                    Author = "Tom",
                    ISBN = "345",
                    Id=Guid.NewGuid() } 
            
            };
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
