using AspNetSandBox.Models;
using System.Collections.Generic;

namespace AspNetSandBox
{
    /// <summary>Interface for CRUD operations on books.</summary>
    public interface IBooksService
    {
        /// <summary>Gets books.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        IEnumerable<Book> Get();

        /// <summary>Gets the book specified by the identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Book Get(int id);

        /// <summary>Adds the specified book.</summary>
        /// <param name="value">The value.</param>
        void Add(Book value);

        /// <summary>Deletes the book specified by identifier.</summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>Updates the book specified by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        void Update(int id, Book value);
    }
}