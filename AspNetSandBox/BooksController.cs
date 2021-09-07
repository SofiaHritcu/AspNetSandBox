using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetSandBox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books;

        static BooksController()
        {
            books = new List<Book>();
            books.Add( new Book
            {
                Id = 1,
                Title = "To Kill A Mocking Bird",
                Author = "Harper Lee",
                Language = "english"
            });

            books.Add( new Book
            {
                Id = 2,
                Title = "Crime&Punishment",
                Author = "Feodor Dostoievski",
                Language = "english"
            });
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return books.Single(b => b.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            int id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
