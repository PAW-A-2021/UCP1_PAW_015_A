using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_015_A.Models;

namespace UCP1_PAW_015_A.Controllers
{
    public class MataPelajaranController : Controller
    {
        private readonly DB_RaportkuContext _context;

        public MataPelajaranController(DB_RaportkuContext context)
        {
            _context = context;
        }

        // GET: MataPelajaran
        public async Task<IActionResult> Index()
        {
            return View(await _context.MataPelajaran.ToListAsync());
        }

        // GET: MataPelajaran/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.MataPelajaran
                .FirstOrDefaultAsync(m => m.IdMatapelajaran == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return View(mataPelajaran);
        }

        // GET: MataPelajaran/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MataPelajaran/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMatapelajaran,NamaMatapelajaran")] MataPelajaran mataPelajaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mataPelajaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mataPelajaran);
        }

        // GET: MataPelajaran/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.MataPelajaran.FindAsync(id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }
            return View(mataPelajaran);
        }

        // POST: MataPelajaran/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMatapelajaran,NamaMatapelajaran")] MataPelajaran mataPelajaran)
        {
            if (id != mataPelajaran.IdMatapelajaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mataPelajaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MataPelajaranExists(mataPelajaran.IdMatapelajaran))
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
            return View(mataPelajaran);
        }

        // GET: MataPelajaran/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.MataPelajaran
                .FirstOrDefaultAsync(m => m.IdMatapelajaran == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return View(mataPelajaran);
        }

        // POST: MataPelajaran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mataPelajaran = await _context.MataPelajaran.FindAsync(id);
            _context.MataPelajaran.Remove(mataPelajaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MataPelajaranExists(int id)
        {
            return _context.MataPelajaran.Any(e => e.IdMatapelajaran == id);
        }
    }
}
