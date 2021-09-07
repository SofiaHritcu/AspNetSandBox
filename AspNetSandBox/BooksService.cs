using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox
{
    public class BooksService : IBooksService
    {
        private static List<Book> books;
        private static int currentId;

        public BooksService()
        {
            books = new List<Book>();
            currentId = 1;
            books.Add(new Book
            {
                Id = GenerateId(),
                Title = "To Kill A Mocking Bird",
                Author = "Harper Lee",
                Language = "english"
            });

            books.Add(new Book
            {
                Id = GenerateId(),
                Title = "Crime&Punishment",
                Author = "Feodor Dostoievski",
                Language = "english"
            });
        }

        private int GenerateId()
        {
            return currentId++;
        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(b => b.Id == id);
        }


        public void Add(Book value)
        {
            if ( value == null)
            {
                throw new Exception("Book cannot be null !");
            }
            else if (value.Author == null || value.Title == null || value.Language == null)
            {
                throw new Exception("Book fields should not be null !");
            }
            value.Id = GenerateId();
            books.Add(value);
        }


        public void Update(int id, string value)
        {
        }


        public void Delete(int id)
        {
            books.Remove(Get(id));
        }

    }
}
