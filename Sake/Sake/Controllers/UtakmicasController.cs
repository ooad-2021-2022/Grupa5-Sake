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
    public class UtakmicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtakmicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Utakmicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utakmica.ToListAsync());
        }

        // GET: Utakmicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utakmica = await _context.Utakmica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utakmica == null)
            {
                return NotFound();
            }

            return View(utakmica);
        }

        // GET: Utakmicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utakmicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDomaćina,IdGosta,VrijemeOdržavanja,MjestoOdržavanja")] Utakmica utakmica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utakmica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utakmica);
        }

        // GET: Utakmicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utakmica = await _context.Utakmica.FindAsync(id);
            if (utakmica == null)
            {
                return NotFound();
            }
            return View(utakmica);
        }

        // POST: Utakmicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdDomaćina,IdGosta,VrijemeOdržavanja,MjestoOdržavanja")] Utakmica utakmica)
        {
            if (id != utakmica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utakmica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtakmicaExists(utakmica.Id))
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
            return View(utakmica);
        }

        // GET: Utakmicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utakmica = await _context.Utakmica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utakmica == null)
            {
                return NotFound();
            }

            return View(utakmica);
        }

        // POST: Utakmicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utakmica = await _context.Utakmica.FindAsync(id);
            _context.Utakmica.Remove(utakmica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtakmicaExists(int id)
        {
            return _context.Utakmica.Any(e => e.Id == id);
        }
    }
}
