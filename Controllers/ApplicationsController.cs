using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Read → Index
        [HttpGet("/Read")]
        public async Task<IActionResult> Read()
        {
            var apps = await _context.Applications.Include(a => a.Student).ToListAsync();
            return View("Index", apps);
        }

        // GET: /Create → Create.cshtml
        [HttpGet("/Create")]
        public IActionResult CreateShortcut()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View("Create");
        }

        // GET: /Update/{id} → Edit.cshtml
        [HttpGet("/Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null) return NotFound();

            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", application.StudentId);
            return View("Edit", application);
        }

        // GET: /Delete/{id} → Delete.cshtml
        [HttpGet("/Delete/{id}")]
        public async Task<IActionResult> DeleteShortcut(string id)
        {
            if (id == null) return NotFound();

            var application = await _context.Applications
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View("Delete", application);
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var applications = await _context.Applications.Include(a => a.Student).ToListAsync();
            return View(applications);
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var application = await _context.Applications
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,Notes,Status,CompanyName,PositionTitle,JobDescription,ApplicationDate,StudentId")] Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", application.StudentId);
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", application.StudentId);
            return View(application);
        }

        // POST: Applications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ApplicationId,Notes,Status,CompanyName,PositionTitle,JobDescription,ApplicationDate,StudentId")] Application application)
        {
            if (id != application.ApplicationId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationId)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", application.StudentId);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var application = await _context.Applications
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(string id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
