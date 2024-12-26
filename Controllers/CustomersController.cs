using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairDesignStudio.Data;
using HairDesignStudio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HairDesignStudio.ViewModels;

namespace HairDesignStudio.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly UserManager<AdvanceUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CustomersController(UserManager<AdvanceUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
        
            var customers = users.Select(u => new CustomerViewModel
            {
                Id = u.Id,
                CustomerName = u.FirstName,
                CustomerSurname = u.LastName,
                CustomerEMail = u.Email,
                CustomerPhoneNumber = u.PhoneNumber
            }).ToList();

            return View(customers);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var customerViewModel = new CustomerViewModel
            {
                Id = user.Id,
                CustomerName = user.FirstName,
                CustomerSurname = user.LastName,
                CustomerEMail = user.Email,
                CustomerPhoneNumber = user.PhoneNumber
            };

            return View(customerViewModel);
        }
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var customerViewModel = new CustomerViewModel
            {
                Id = user.Id,
                CustomerName = user.FirstName,
                CustomerSurname = user.LastName,
                CustomerEMail = user.Email,
                CustomerPhoneNumber = user.PhoneNumber
            };

            return View(customerViewModel);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CustomerViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = model.CustomerName;
                user.LastName = model.CustomerSurname;
                user.PhoneNumber = model.CustomerPhoneNumber;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

    }
}
