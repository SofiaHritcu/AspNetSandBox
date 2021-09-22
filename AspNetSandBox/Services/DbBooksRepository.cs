using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandBox.Data;
using AspNetSandBox.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Services
{
    /// <summary>DbBooksRepository.</summary>
    public class DbBooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>Initializes a new instance of the <see cref="DbBooksRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Adds the specified book.</summary>
        /// <param name="book">The book.</param>
        public void Add(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        /// <summary>Deletes the book specified by identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        /// <summary>Gets books.</summary>
        /// <returns>Ienumerable of Books.<br /></returns>
        public IEnumerable<Book> Get()
        {
            return context.Book.ToList();
        }

        /// <summary>Gets the book specified by the identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book Object.<br /></returns>
        public Book Get(int id)
        {
            var book = context.Book.FirstOrDefault(m => m.Id == id);
            return book;
        }

        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        public void Update(int id, Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }
    }
}
