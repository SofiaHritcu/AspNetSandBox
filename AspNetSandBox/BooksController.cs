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
        private IBooksService booksService;
        
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.Get();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.Get(id));
            } catch (Exception e)
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.Update(id, value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.Delete(id);
        }
    }
}
