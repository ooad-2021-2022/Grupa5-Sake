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
    public class IgranjeZaTimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IgranjeZaTimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IgranjeZaTims
        public async Task<IActionResult> Index()
        {
            return View(await _context.IgranjeZaTim.ToListAsync());
        }

        // GET: IgranjeZaTims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igranjeZaTim = await _context.IgranjeZaTim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igranjeZaTim == null)
            {
                return NotFound();
            }

            return View(igranjeZaTim);
        }

        // GET: IgranjeZaTims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IgranjeZaTims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTima,IdIgrača")] IgranjeZaTim igranjeZaTim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(igranjeZaTim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(igranjeZaTim);
        }

        // GET: IgranjeZaTims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igranjeZaTim = await _context.IgranjeZaTim.FindAsync(id);
            if (igranjeZaTim == null)
            {
                return NotFound();
            }
            return View(igranjeZaTim);
        }

        // POST: IgranjeZaTims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTima,IdIgrača")] IgranjeZaTim igranjeZaTim)
        {
            if (id != igranjeZaTim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(igranjeZaTim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IgranjeZaTimExists(igranjeZaTim.Id))
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
            return View(igranjeZaTim);
        }

        // GET: IgranjeZaTims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igranjeZaTim = await _context.IgranjeZaTim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igranjeZaTim == null)
            {
                return NotFound();
            }

            return View(igranjeZaTim);
        }

        // POST: IgranjeZaTims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var igranjeZaTim = await _context.IgranjeZaTim.FindAsync(id);
            _context.IgranjeZaTim.Remove(igranjeZaTim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IgranjeZaTimExists(int id)
        {
            return _context.IgranjeZaTim.Any(e => e.Id == id);
        }
    }
}
