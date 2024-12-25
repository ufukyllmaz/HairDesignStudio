using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HairDesginStudio.Views.Reservations
{
    public class SelectTime : PageModel
    {
        private readonly ILogger<SelectTime> _logger;

        public SelectTime(ILogger<SelectTime> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}