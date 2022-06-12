using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sake.Data;
using Sake.Models;

namespace Sake.Controllers
{
    public class LutrijasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LutrijasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lutrijas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lutrija.ToListAsync());
        }

        // GET: Lutrijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lutrija = await _context.Lutrija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lutrija == null)
            {
                return NotFound();
            }

            return View(lutrija);
        }

        // GET: Lutrijas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lutrijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdKorisnika,IdUtakmice,IdPobjednika,NagradniBodovi")] Lutrija lutrija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lutrija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lutrija);
        }

        // GET: Lutrijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lutrija = await _context.Lutrija.FindAsync(id);
            if (lutrija == null)
            {
                return NotFound();
            }
            return View(lutrija);
        }

        // POST: Lutrijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdKorisnika,IdUtakmice,IdPobjednika,NagradniBodovi")] Lutrija lutrija)
        {
            if (id != lutrija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lutrija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LutrijaExists(lutrija.Id))
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
            return View(lutrija);
        }

        // GET: Lutrijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lutrija = await _context.Lutrija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lutrija == null)
            {
                return NotFound();
            }

            return View(lutrija);
        }

        // POST: Lutrijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lutrija = await _context.Lutrija.FindAsync(id);
            _context.Lutrija.Remove(lutrija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LutrijaExists(int id)
        {
            return _context.Lutrija.Any(e => e.Id == id);
        }
    }
}
