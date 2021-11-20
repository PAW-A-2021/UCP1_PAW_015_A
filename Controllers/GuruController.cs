using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_015_A.Models;

namespace UCP1_PAW_015_A.Controllers
{
    public class GuruController : Controller
    {
        private readonly DB_RaportkuContext _context;

        public GuruController(DB_RaportkuContext context)
        {
            _context = context;
        }

        // GET: Guru
        public async Task<IActionResult> Index()
        {
            var dB_RaportkuContext = _context.Guru.Include(g => g.IdJeniskelaminNavigation).Include(g => g.IdMatapelajaranNavigation);
            return View(await dB_RaportkuContext.ToListAsync());
        }

        // GET: Guru/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Guru
                .Include(g => g.IdJeniskelaminNavigation)
                .Include(g => g.IdMatapelajaranNavigation)
                .FirstOrDefaultAsync(m => m.IdGuru == id);
            if (guru == null)
            {
                return NotFound();
            }

            return View(guru);
        }

        // GET: Guru/Create
        public IActionResult Create()
        {
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin");
            ViewData["IdMatapelajaran"] = new SelectList(_context.MataPelajaran, "IdMatapelajaran", "IdMatapelajaran");
            return View();
        }

        // POST: Guru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGuru,NamaGuru,IdJeniskelamin,IdMatapelajaran")] Guru guru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin", guru.IdJeniskelamin);
            ViewData["IdMatapelajaran"] = new SelectList(_context.MataPelajaran, "IdMatapelajaran", "IdMatapelajaran", guru.IdMatapelajaran);
            return View(guru);
        }

        // GET: Guru/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Guru.FindAsync(id);
            if (guru == null)
            {
                return NotFound();
            }
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin", guru.IdJeniskelamin);
            ViewData["IdMatapelajaran"] = new SelectList(_context.MataPelajaran, "IdMatapelajaran", "IdMatapelajaran", guru.IdMatapelajaran);
            return View(guru);
        }

        // POST: Guru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGuru,NamaGuru,IdJeniskelamin,IdMatapelajaran")] Guru guru)
        {
            if (id != guru.IdGuru)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuruExists(guru.IdGuru))
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
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin", guru.IdJeniskelamin);
            ViewData["IdMatapelajaran"] = new SelectList(_context.MataPelajaran, "IdMatapelajaran", "IdMatapelajaran", guru.IdMatapelajaran);
            return View(guru);
        }

        // GET: Guru/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Guru
                .Include(g => g.IdJeniskelaminNavigation)
                .Include(g => g.IdMatapelajaranNavigation)
                .FirstOrDefaultAsync(m => m.IdGuru == id);
            if (guru == null)
            {
                return NotFound();
            }

            return View(guru);
        }

        // POST: Guru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guru = await _context.Guru.FindAsync(id);
            _context.Guru.Remove(guru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuruExists(int id)
        {
            return _context.Guru.Any(e => e.IdGuru == id);
        }
    }
}
