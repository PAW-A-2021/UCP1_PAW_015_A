using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_015_A.Models;

namespace UCP1_PAW_015_A.Controllers
{
    public class NilaiController : Controller
    {
        private readonly DB_RaportkuContext _context;

        public NilaiController(DB_RaportkuContext context)
        {
            _context = context;
        }

        // GET: Nilai
        public async Task<IActionResult> Index()
        {
            var dB_RaportkuContext = _context.Nilai.Include(n => n.IdSiswaNavigation);
            return View(await dB_RaportkuContext.ToListAsync());
        }

        // GET: Nilai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nilai = await _context.Nilai
                .Include(n => n.IdSiswaNavigation)
                .FirstOrDefaultAsync(m => m.IdNilai == id);
            if (nilai == null)
            {
                return NotFound();
            }

            return View(nilai);
        }

        // GET: Nilai/Create
        public IActionResult Create()
        {
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "IdSiswa");
            return View();
        }

        // POST: Nilai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNilai,IdSiswa,JumlahNilai")] Nilai nilai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nilai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "IdSiswa", nilai.IdSiswa);
            return View(nilai);
        }

        // GET: Nilai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nilai = await _context.Nilai.FindAsync(id);
            if (nilai == null)
            {
                return NotFound();
            }
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "IdSiswa", nilai.IdSiswa);
            return View(nilai);
        }

        // POST: Nilai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNilai,IdSiswa,JumlahNilai")] Nilai nilai)
        {
            if (id != nilai.IdNilai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nilai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NilaiExists(nilai.IdNilai))
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
            ViewData["IdSiswa"] = new SelectList(_context.Siswa, "IdSiswa", "IdSiswa", nilai.IdSiswa);
            return View(nilai);
        }

        // GET: Nilai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nilai = await _context.Nilai
                .Include(n => n.IdSiswaNavigation)
                .FirstOrDefaultAsync(m => m.IdNilai == id);
            if (nilai == null)
            {
                return NotFound();
            }

            return View(nilai);
        }

        // POST: Nilai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nilai = await _context.Nilai.FindAsync(id);
            _context.Nilai.Remove(nilai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NilaiExists(int id)
        {
            return _context.Nilai.Any(e => e.IdNilai == id);
        }
    }
}
