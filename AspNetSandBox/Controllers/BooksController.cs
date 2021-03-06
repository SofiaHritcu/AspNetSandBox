using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandBox.Data;
using AspNetSandBox.DTOs;
using AspNetSandBox.Hubs;
using AspNetSandBox.Models;
using AspNetSandBox.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

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
        /// <param name="dbBooksRepository">Db Books Repository.</param>
        /// <param name="hubContext">Hub Context.</param>
        /// <param name="mapper">
        ///   <para>The mapper.</para>
        /// </param>
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
        public IActionResult Get()
        {
            var books = dbBooksRepository.Get();
            var readBookDtos = mapper.Map<IEnumerable<Book>, IEnumerable<ReadBookDto>>(books);
            return Ok(readBookDtos);
        }

        // GET api/<ValuesController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
        /// <param name="createBookDto">
        ///   <para>The book to be added.</para>
        /// </param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDto createBookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(createBookDto);
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
        /// <param name="book"> The book to be updated.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            dbBooksRepository.Update(id, book);
            hubContext.Clients.All.SendAsync("BookUpdated", book);
            return Ok();
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            dbBooksRepository.Delete(id);
            hubContext.Clients.All.SendAsync("BookDeleted", id);
            return Ok();
        }
    }
}
