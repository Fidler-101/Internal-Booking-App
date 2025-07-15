using Microsoft.AspNetCore.Mvc;
using Internal_Booking_App.Data;
using Internal_Booking_App.Models;

namespace Internal_Booking_App.Controllers
{
    public class ResourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Resource
        public IActionResult Index()
        {
            var resources = _context.Resources.ToList();
            return View(resources);
        }

        // GET: /Resource/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Resource/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Resources.Add(resource);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: /Resource/Edit/5
        public IActionResult Edit(int id)
        {
            var resource = _context.Resources.Find(id);
            if (resource == null) return NotFound();
            return View(resource);
        }

        // POST: /Resource/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Resources.Update(resource);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: /Resource/Delete/5
        public IActionResult Delete(int id)
        {
            var resource = _context.Resources.Find(id);
            if (resource == null) return NotFound();
            return View(resource);
        }

        // POST: /Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var resource = _context.Resources.Find(id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Resource/Details/5
        public IActionResult Details(int id)
        {
            var resource = _context.Resources.Find(id);
            if (resource == null) return NotFound();
            return View(resource);
        }
    }
}
