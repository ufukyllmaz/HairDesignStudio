using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HairDesignStudio.Views.Reservations
{
    public class SelectService : PageModel
    {
        private readonly ILogger<SelectService> _logger;

        public SelectService(ILogger<SelectService> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}