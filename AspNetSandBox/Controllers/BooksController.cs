using AspNetSandBox.Data;
using AspNetSandBox.DTOs;
using AspNetSandBox.Models;
using AspNetSandBox.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandBox.Controllers
{
    /// <summary>BooksController .
    /// Exposes api CRUD operations for books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository dbBooksRepository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        /// <param name="context">ApplicationDbContext.</param>
        public BooksController(IBooksRepository dbBooksRepository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.dbBooksRepository = dbBooksRepository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        // GET: api/<ValuesController>

        /// <summary>Gets all the instances of books.</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(dbBooksRepository.Get());
        }

        // GET api/<ValuesController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Book book = dbBooksRepository.Get(id);
                ReadBookDto readBookDto = mapper.Map<ReadBookDto>(book);
                return Ok(readBookDto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>

        /// <summary>Posts the specified book.</summary>
        /// <param name="bookDto">The value.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                dbBooksRepository.Add(book);
                hubContext.Clients.All.SendAsync("BookCreated", book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ValuesController>/

        /// <summary>Updates the book at the specified id with the fields of value.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The value.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            dbBooksRepository.Update(id, book);
            hubContext.Clients.All.SendAsync("BookUpdated", book);
            return Ok();
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            dbBooksRepository.Delete(id);
            hubContext.Clients.All.SendAsync("BookDeleted", id);
            return Ok();
        }
    }
}
