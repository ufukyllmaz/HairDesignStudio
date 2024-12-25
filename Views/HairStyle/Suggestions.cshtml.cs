using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HairDesginStudio.Views.HairStyle
{
    public class Suggestions : PageModel
    {
        private readonly ILogger<Suggestions> _logger;

        public Suggestions(ILogger<Suggestions> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}