using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_015_A.Models;

namespace UCP1_PAW_015_A.Controllers
{
    public class SiswaController : Controller
    {
        private readonly DB_RaportkuContext _context;

        public SiswaController(DB_RaportkuContext context)
        {
            _context = context;
        }

        // GET: Siswa
        public async Task<IActionResult> Index()
        {
            var dB_RaportkuContext = _context.Siswa.Include(s => s.IdJeniskelaminNavigation).Include(s => s.IdKelasNavigation);
            return View(await dB_RaportkuContext.ToListAsync());
        }

        // GET: Siswa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.IdJeniskelaminNavigation)
                .Include(s => s.IdKelasNavigation)
                .FirstOrDefaultAsync(m => m.IdSiswa == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // GET: Siswa/Create
        public IActionResult Create()
        {
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin");
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas");
            return View();
        }

        // POST: Siswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSiswa,NamaSiswa,IdJeniskelamin,IdKelas")] Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin", siswa.IdJeniskelamin);
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas", siswa.IdKelas);
            return View(siswa);
        }

        // GET: Siswa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin", siswa.IdJeniskelamin);
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas", siswa.IdKelas);
            return View(siswa);
        }

        // POST: Siswa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiswa,NamaSiswa,IdJeniskelamin,IdKelas")] Siswa siswa)
        {
            if (id != siswa.IdSiswa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaExists(siswa.IdSiswa))
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
            ViewData["IdJeniskelamin"] = new SelectList(_context.JenisKelamin, "IdJeniskelamin", "IdJeniskelamin", siswa.IdJeniskelamin);
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas", siswa.IdKelas);
            return View(siswa);
        }

        // GET: Siswa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.IdJeniskelaminNavigation)
                .Include(s => s.IdKelasNavigation)
                .FirstOrDefaultAsync(m => m.IdSiswa == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // POST: Siswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siswa = await _context.Siswa.FindAsync(id);
            _context.Siswa.Remove(siswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaExists(int id)
        {
            return _context.Siswa.Any(e => e.IdSiswa == id);
        }
    }
}
