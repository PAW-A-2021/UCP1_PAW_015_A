using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_015_A.Models;

namespace UCP1_PAW_015_A.Controllers
{
    public class KelasController : Controller
    {
        private readonly DB_RaportkuContext _context;

        public KelasController(DB_RaportkuContext context)
        {
            _context = context;
        }

        // GET: Kelas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kelas.ToListAsync());
        }

        // GET: Kelas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelas = await _context.Kelas
                .FirstOrDefaultAsync(m => m.IdKelas == id);
            if (kelas == null)
            {
                return NotFound();
            }

            return View(kelas);
        }

        // GET: Kelas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kelas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKelas,NamaKelas")] Kelas kelas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kelas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kelas);
        }

        // GET: Kelas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelas = await _context.Kelas.FindAsync(id);
            if (kelas == null)
            {
                return NotFound();
            }
            return View(kelas);
        }

        // POST: Kelas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKelas,NamaKelas")] Kelas kelas)
        {
            if (id != kelas.IdKelas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kelas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KelasExists(kelas.IdKelas))
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
            return View(kelas);
        }

        // GET: Kelas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelas = await _context.Kelas
                .FirstOrDefaultAsync(m => m.IdKelas == id);
            if (kelas == null)
            {
                return NotFound();
            }

            return View(kelas);
        }

        // POST: Kelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kelas = await _context.Kelas.FindAsync(id);
            _context.Kelas.Remove(kelas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KelasExists(int id)
        {
            return _context.Kelas.Any(e => e.IdKelas == id);
        }
    }
}
