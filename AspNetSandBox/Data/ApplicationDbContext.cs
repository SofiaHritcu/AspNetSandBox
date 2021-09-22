using System;
using System.Collections.Generic;
using System.Text;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Data
{
    /// <summary>ApplicationDbContext.</summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationDbContext" /> class.</summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        public DbSet<Book> Book { get; set; }
    }
}
