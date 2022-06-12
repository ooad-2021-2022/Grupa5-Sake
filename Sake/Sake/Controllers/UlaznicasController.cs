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
    public class UlaznicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UlaznicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ulaznicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ulaznica.ToListAsync());
        }

        // GET: Ulaznicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ulaznica = await _context.Ulaznica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ulaznica == null)
            {
                return NotFound();
            }

            return View(ulaznica);
        }

        // GET: Ulaznicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ulaznicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUtakmice,IdGledanja,Cijena,Dostupna")] Ulaznica ulaznica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ulaznica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ulaznica);
        }

        // GET: Ulaznicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ulaznica = await _context.Ulaznica.FindAsync(id);
            if (ulaznica == null)
            {
                return NotFound();
            }
            return View(ulaznica);
        }

        // POST: Ulaznicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUtakmice,IdGledanja,Cijena,Dostupna")] Ulaznica ulaznica)
        {
            if (id != ulaznica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ulaznica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UlaznicaExists(ulaznica.Id))
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
            return View(ulaznica);
        }

        // GET: Ulaznicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ulaznica = await _context.Ulaznica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ulaznica == null)
            {
                return NotFound();
            }

            return View(ulaznica);
        }

        // POST: Ulaznicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ulaznica = await _context.Ulaznica.FindAsync(id);
            _context.Ulaznica.Remove(ulaznica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UlaznicaExists(int id)
        {
            return _context.Ulaznica.Any(e => e.Id == id);
        }
    }
}
