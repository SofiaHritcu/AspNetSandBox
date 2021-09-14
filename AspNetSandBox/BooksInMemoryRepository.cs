using AspNetSandBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetSandBox
{
    /// <summary>CRUD opertaions implementations for books.</summary>
    public class BooksInMemoryRepository : IBooksRepository
    {
        private static List<Book> books;
        private static int currentId;

        /// <summary>Initializes a new instance of the <see cref="BooksInMemoryRepository" /> class.</summary>
        public BooksInMemoryRepository()
        {
            books = new List<Book>();
            currentId = 1;
            books.Add(new Book
            {
                Id = GenerateId(),
                Title = "To Kill A Mocking Bird",
                Author = "Harper Lee",
                Language = "english",
            });

            books.Add(new Book
            {
                Id = GenerateId(),
                Title = "Crime&Punishment",
                Author = "Feodor Dostoievski",
                Language = "english",
            });
        }

        /// <summary>Gets all instances of books.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IEnumerable<Book> Get()
        {
            return books;
        }

        /// <summary>Gets the  book specified by the identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Book Get(int id)
        {
            CheckId(id);
            return books.Single(_ => _.Id == id);
        }

        /// <summary>Adds the specified book.</summary>
        /// <param name="value">The value.</param>
        public void Add(Book value)
        {
            CheckBook(value);
            value.Id = GenerateId();
            books.Add(value);
        }

        /// <summary>Updates the book specified by identifier with value fields.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void Update(int id, Book value)
        {
            CheckBook(value);
            Book bookToBeUpdated = Get(id);
            bookToBeUpdated.Author = value.Author;
            bookToBeUpdated.Title = value.Title;
            bookToBeUpdated.Language = value.Language;
        }

        /// <summary>Deletes the book specified by the identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            books.Remove(Get(id));
        }

        private static void CheckId(int id)
        {
            if (id < 1 || id >= currentId)
            {
                throw new Exception("Invalid id !");
            }
        }

        private static void CheckBook(Book value)
        {
            if (value == null)
            {
                throw new Exception("Book cannot be null !");
            }
            else if (value.Author == null || value.Title == null || value.Language == null)
            {
                throw new Exception("Book fields should not be null !");
            }
        }

        private int GenerateId()
        {
            return currentId++;
        }
    }
}
