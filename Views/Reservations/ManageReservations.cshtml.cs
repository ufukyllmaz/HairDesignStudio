using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HairDesignStudio.Views.Reservations
{
    public class ManageReservations : PageModel
    {
        private readonly ILogger<ManageReservations> _logger;

        public ManageReservations(ILogger<ManageReservations> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}