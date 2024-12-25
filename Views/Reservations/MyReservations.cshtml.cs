using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HairDesginStudio.Views.Reservations
{
    public class MyReservations : PageModel
    {
        private readonly ILogger<MyReservations> _logger;

        public MyReservations(ILogger<MyReservations> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}