using AspNetSandBox.Data;
using AspNetSandBox.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.Services
{
    public class DbBooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext context;

        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> Get()
        {
            return context.Book.ToList();
        }

        public Book Get(int id)
        {
            var book = context.Book.FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void Update(int id, Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }
    }
}
