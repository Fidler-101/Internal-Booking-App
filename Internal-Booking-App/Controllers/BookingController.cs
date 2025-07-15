using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Internal_Booking_App.Data;
using Internal_Booking_App.Models;

namespace Internal_Booking_App.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Booking
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Resource)
                .OrderBy(b => b.StartTime)
                .ToListAsync();

            return View(bookings);
        }

        // GET: /Booking/Create
        public IActionResult Create()
        {
            ViewBag.ResourceList = new SelectList(
                _context.Resources.Where(r => r.IsAvailable),
                "Id",
                "Name"
            );

            return View();
        }

        // POST: /Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            // Validation: EndTime must be after StartTime
            if (booking.StartTime >= booking.EndTime)
            {
                ModelState.AddModelError("", "End Time must be after Start Time.");
            }

            // Validation: Booking conflict check
            bool hasConflict = await _context.Bookings.AnyAsync(b =>
                b.ResourceId == booking.ResourceId &&
                b.EndTime > booking.StartTime &&
                b.StartTime < booking.EndTime
            );

            if (hasConflict)
            {
                ModelState.AddModelError("", "This resource is already booked during the selected time.");
            }

            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Re-bind dropdown with selected item preserved
            ViewBag.ResourceList = new SelectList(
                _context.Resources.Where(r => r.IsAvailable),
                "Id",
                "Name",
                booking.ResourceId
            );

            return View(booking);
        }

  
    }
}
