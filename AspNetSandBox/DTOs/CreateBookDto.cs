using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.DTOs
{
    /// <summary>CreateBookDto .</summary>
    public class CreateBookDto
    {
        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        public string Author { get; set; }

        /// <summary>Gets or sets the language.</summary>
        /// <value>The language.</value>
        public string Language { get; set; }
    }
}
