using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_015_A.Models;

namespace UCP1_PAW_015_A.Controllers
{
    public class JenisKelaminController : Controller
    {
        private readonly DB_RaportkuContext _context;

        public JenisKelaminController(DB_RaportkuContext context)
        {
            _context = context;
        }

        // GET: JenisKelamin
        public async Task<IActionResult> Index()
        {
            return View(await _context.JenisKelamin.ToListAsync());
        }

        // GET: JenisKelamin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisKelamin = await _context.JenisKelamin
                .FirstOrDefaultAsync(m => m.IdJeniskelamin == id);
            if (jenisKelamin == null)
            {
                return NotFound();
            }

            return View(jenisKelamin);
        }

        // GET: JenisKelamin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisKelamin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJeniskelamin,NamaJeniskelamin")] JenisKelamin jenisKelamin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisKelamin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisKelamin);
        }

        // GET: JenisKelamin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisKelamin = await _context.JenisKelamin.FindAsync(id);
            if (jenisKelamin == null)
            {
                return NotFound();
            }
            return View(jenisKelamin);
        }

        // POST: JenisKelamin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJeniskelamin,NamaJeniskelamin")] JenisKelamin jenisKelamin)
        {
            if (id != jenisKelamin.IdJeniskelamin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisKelamin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisKelaminExists(jenisKelamin.IdJeniskelamin))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jenisKelamin);
        }

        // GET: JenisKelamin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisKelamin = await _context.JenisKelamin
                .FirstOrDefaultAsync(m => m.IdJeniskelamin == id);
            if (jenisKelamin == null)
            {
                return NotFound();
            }

            return View(jenisKelamin);
        }

        // POST: JenisKelamin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jenisKelamin = await _context.JenisKelamin.FindAsync(id);
            _context.JenisKelamin.Remove(jenisKelamin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisKelaminExists(int id)
        {
            return _context.JenisKelamin.Any(e => e.IdJeniskelamin == id);
        }
    }
}
