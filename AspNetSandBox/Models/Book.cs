using System.Diagnostics;

namespace AspNetSandBox.Models
{
    /// <summary>Book Class.</summary>
    [DebuggerDisplay("Title = {x} Id = {y}")]
    public class Book
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        public string Author { get; set; }

        /// <summary>Gets or sets the language.</summary>
        /// <value>The language.</value>
        public string Language { get; set; }

        /// <summary>Gets or sets the purchase price.</summary>
        /// <value>The purchase price.</value>
        public decimal PurchasePrice { get; set; }
    }
}
