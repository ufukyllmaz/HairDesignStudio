using System.Security.Claims;
using HairDesginStudio.Data;
using HairDesginStudio.Models;
using HairDesginStudio.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class ReservationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReservationsController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        // Kullanıcı direkt olarak rezervasyon oluşturma sayfasına yönlendirilsin
        return RedirectToAction(nameof(Create));
    }

    // İlk adım - Tarih seçimi
    public IActionResult Create()
    {
        var dates = Enumerable.Range(0, 7)
            .Select(offset => DateTime.Today.AddDays(offset))
            .ToList();
        
        return View(dates);
    }

    // İkinci adım - İşlem ve personel seçimi
    [HttpPost]
    public IActionResult SelectService(string selectedDate)
    {
        // DateTime.Parse yerine DateTime.TryParse kullanıyoruz
        if (DateTime.TryParse(selectedDate, out DateTime date))
        {
            var viewModel = new ServiceSelectionViewModel
            {
                SelectedDate = date,
                Operations = _context.Operations.ToList(),
                Workers = _context.Workers.ToList()
            };
            
            return View(viewModel);
        }
        
        // Tarih dönüştürülemezse ana sayfaya geri dön
        return RedirectToAction(nameof(Create));
    }

    [HttpPost]
    public async Task<IActionResult> SelectTime(int workerId, int operationId, DateTime selectedDate)
    {
        try
        {
            var operation = await _context.Operations.FindAsync(operationId);
            var worker = await _context.Workers.FindAsync(workerId);
            
            if (operation == null || worker == null)
            {
                return RedirectToAction(nameof(Create));
            }

            // O güne ait tüm rezervasyonları getir
            var existingReservations = await _context.Reservations
                .Where(r => r.WorkerId == workerId && r.ReservationDate.Date == selectedDate.Date)
                .Include(r => r.Operation)  // İşlem süresini alabilmek için
                .ToListAsync();

            var allTimeSlots = new List<TimeViewModel>();
            var startTime = TimeSpan.FromHours(9);  // 09:00
            var endTime = TimeSpan.FromHours(19);   // 19:00

            while (startTime.Add(TimeSpan.FromMinutes(operation.OperationDuration)) <= endTime)
            {
                bool isSlotAvailable = true;
                foreach (var reservation in existingReservations)
                {
                    // Bu zaman diliminde çakışma var mı kontrol et
                    if (startTime < reservation.ReservationTime.Add(TimeSpan.FromMinutes(reservation.Operation.OperationDuration)) &&
                        startTime.Add(TimeSpan.FromMinutes(operation.OperationDuration)) > reservation.ReservationTime)
                    {
                        isSlotAvailable = false;
                        break;
                    }
                }

                allTimeSlots.Add(new TimeViewModel 
                { 
                    Time = startTime,
                    DisplayTime = startTime.ToString(@"hh\:mm"),
                    IsAvailable = isSlotAvailable,
                    ExistingReservation = existingReservations
                        .FirstOrDefault(r => r.ReservationTime == startTime)
                });

                startTime = startTime.Add(TimeSpan.FromHours(1));
            }

            var viewModel = new TimeSelectionViewModel
            {
                SelectedDate = selectedDate,
                WorkerId = workerId,
                OperationId = operationId,
                Worker = worker,
                Operation = operation,
                AllTimeSlots = allTimeSlots  // Tüm zaman dilimlerini gönder
            };

            return View(viewModel);
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Bir hata oluştu: " + ex.Message;
            return RedirectToAction(nameof(Create));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Confirm(string selectedTime, int workerId, int operationId, DateTime selectedDate)
    {
        try
        {
            // Zaman dilimini TimeSpan'e çevir
            var time = TimeSpan.Parse(selectedTime);

            // Gerekli nesneleri veritabanından al
            var operation = await _context.Operations.FindAsync(operationId);
            var worker = await _context.Workers.FindAsync(workerId);

            if (operation == null || worker == null)
            {
                TempData["Error"] = "İşlem veya personel bulunamadı.";
                return RedirectToAction(nameof(Create));
            }

            // Yeni rezervasyon oluştur
            var reservation = new Reservations
            {
                WorkerId = workerId,
                OperationId = operationId,
                ReservationDate = selectedDate.Date,
                ReservationTime = time,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                CreatedAt = DateTime.Now
            };

            // Veritabanına ekle
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Rezervasyonunuz başarıyla oluşturuldu!";
            return RedirectToAction(nameof(Success));
        }
        catch (Exception ex)
        {
            // Hata logla
            Console.WriteLine($"Rezervasyon oluşturulurken hata: {ex.Message}");
            TempData["Error"] = "Rezervasyon oluşturulurken bir hata oluştu.";
            return RedirectToAction(nameof(Create));
        }
    }

    public IActionResult Success()
    {
        return View();
    }
    public async Task<IActionResult> MyReservations()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var reservations = await _context.Reservations
            .Include(r => r.Worker)
            .Include(r => r.Operation)
            .Where(r => r.UserId == userId)
            .OrderBy(r => r.ReservationDate)
            .ToListAsync();

        var sortedReservations = reservations
            .OrderBy(r => r.ReservationDate)
            .ThenBy(r => r.ReservationTime)
            .ToList();

        return View(sortedReservations);
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ManageReservations()
    {
        var reservations = await _context.Reservations
            .Include(r => r.Worker)
            .Include(r => r.Operation)
            .Include(r => r.User) 
            .OrderBy(r => r.ReservationDate)
            .ToListAsync();

        var sortedReservations = reservations
            .OrderBy(r => r.ReservationDate)
            .ThenBy(r => r.ReservationTime)
            .ToList();

        return View(sortedReservations);
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminCancelReservation(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Rezervasyon başarıyla iptal edildi.";
        }
        
        return RedirectToAction(nameof(ManageReservations));
    }

    // Normal kullanıcı için iptal metodu
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CancelReservation(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(r => r.ReservationId == id && r.UserId == userId);

        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Rezervasyonunuz başarıyla iptal edildi.";
        }
        else
        {
            TempData["Error"] = "Rezervasyon bulunamadı veya iptal etme yetkiniz yok.";
        }

        return RedirectToAction(nameof(MyReservations));
    }
}