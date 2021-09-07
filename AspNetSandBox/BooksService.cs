using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox
{
    public class BooksService : IBooksService
    {
        private static List<Book> books;

        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "To Kill A Mocking Bird",
                Author = "Harper Lee",
                Language = "english"
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "Crime&Punishment",
                Author = "Feodor Dostoievski",
                Language = "english"
            });
        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(b => b.Id == id);
        }


        public void Update(Book value)
        {
            int id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }


        public void Put(int id, string value)
        {
        }


        public void Delete(int id)
        {
            books.Remove(Get(id));
        }

    }
}
