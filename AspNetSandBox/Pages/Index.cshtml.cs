using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetSandBox.Pages
{
    /// <summary>IndexModel.</summary>
#pragma warning disable SA1649 // File name should match first type name
    public class IndexModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>Initializes a new instance of the <see cref="IndexModel" /> class.</summary>
        public IndexModel()
        {
        }

        /// <summary>Called when [get].</summary>
        public void OnGet()
        {
        }
    }
}
