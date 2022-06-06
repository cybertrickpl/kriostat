using Kriostat.Lib.Common.Entities;
using Kriostat.Lib.Common.Interfaces;

namespace Kriostat.Lib.BooksRepository.FS
{
    public class BookRepositoryFS: IBookRepository
    {
        public void Add(string title, string author, string ISBN)
        {
           
            var tmplist = LoadFromRepository();
            Book book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Author = author,
                ISBN = ISBN,
                
            };

            tmplist.Add(book);
            SaveToRepository(tmplist);

        }

        public void Edit(Guid id, string title, string author, string ISBN)
        {

            var tmplist = LoadFromRepository();
            var editRow = tmplist.Single(p => p.Id == id);
            editRow.Title = title;
            editRow.Author = author;
            editRow.ISBN = ISBN;
       

            SaveToRepository(tmplist);

        }

        public void Delete(Guid Id)
        {
            var tmplist = LoadFromRepository();
            

            tmplist.RemoveAll(b=>b.Id == Id);
            SaveToRepository(tmplist);

        }

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
        public int SaveToRepository(List<Book> list)
        {
            //List<Book> books = LoadFromRepository();
            //books.Add(book);


            System.Xml.Serialization.XmlSerializer writer =
                   new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));

            string? path = System.IO.Path.Combine("c:\\Test", "Repository.xml");

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, list);

            file.Close();
            return 0;
            
        }

        public void Update(Guid Id, string title, string author, string ISBN)
        {
            throw new NotImplementedException();
        }
    }
}
