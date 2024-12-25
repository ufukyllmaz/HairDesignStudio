using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HairDesginStudio.Services;
using HairDesginStudio.ViewModels;

namespace HairDesginStudio.Controllers
{
    [Route("[controller]")]
    public class HairStyleController : Controller
    {
        private readonly IHairStyleService _hairStyleService;
        private readonly ILogger<HairStyleController> _logger;

        public HairStyleController(IHairStyleService hairStyleService, ILogger<HairStyleController> logger)
        {
            _hairStyleService = hairStyleService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new HairStyleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> GenerateStyles(IFormFile photo)
        {
            var viewModel = new HairStyleViewModel();

            try
            {
                if (photo == null || photo.Length == 0)
                {
                    viewModel.ErrorMessage = "Lütfen bir fotoğraf yükleyin.";
                    return View("Index", viewModel);
                }

                using var memoryStream = new MemoryStream();
                await photo.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();

                viewModel.IsLoading = true;
                viewModel.InfoMessage = "Stiller oluşturuluyor, lütfen bekleyin...";

                viewModel.GeneratedStyles = await _hairStyleService.GenerateHairStyles(imageBytes);
                viewModel.IsLoading = false;
                viewModel.InfoMessage = null;

                return View("Index", viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Style generation error: {ex.Message}");
                viewModel.ErrorMessage = "Üzgünüz, şu anda stil önerileri oluşturulamıyor. Lütfen daha sonra tekrar deneyin.";
                viewModel.IsLoading = false;
                return View("Index", viewModel);
            }
        }
    }
}