using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandBox.Controllers
{
    /// <summary>BooksController .
    /// Exposes api CRUD operations for books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        /// <param name="booksService">The books service.</param>
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<ValuesController>

        /// <summary>Gets all the instances of books.</summary>
        /// <returns>Enumerable of book objects.<br /></returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.Get();
        }

        // GET api/<ValuesController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.Get(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>

        /// <summary>Posts the specified book.</summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.Add(value);
        }

        // PUT api/<ValuesController>/

        /// <summary>Updates the book at the specified id with the fields of value.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.Update(id, value);
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.Delete(id);
        }
    }
}
