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
    public class SportskiTimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportskiTimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SportskiTims
        public async Task<IActionResult> Index()
        {
            return View(await _context.SportskiTim.ToListAsync());
        }

        // GET: SportskiTims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportskiTim = await _context.SportskiTim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportskiTim == null)
            {
                return NotFound();
            }

            return View(sportskiTim);
        }

        // GET: SportskiTims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportskiTims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] SportskiTim sportskiTim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportskiTim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportskiTim);
        }

        // GET: SportskiTims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportskiTim = await _context.SportskiTim.FindAsync(id);
            if (sportskiTim == null)
            {
                return NotFound();
            }
            return View(sportskiTim);
        }

        // POST: SportskiTims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] SportskiTim sportskiTim)
        {
            if (id != sportskiTim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportskiTim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportskiTimExists(sportskiTim.Id))
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
            return View(sportskiTim);
        }

        // GET: SportskiTims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportskiTim = await _context.SportskiTim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportskiTim == null)
            {
                return NotFound();
            }

            return View(sportskiTim);
        }

        // POST: SportskiTims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportskiTim = await _context.SportskiTim.FindAsync(id);
            _context.SportskiTim.Remove(sportskiTim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportskiTimExists(int id)
        {
            return _context.SportskiTim.Any(e => e.Id == id);
        }
    }
}
