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
    public class IgračController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IgračController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Igrač
        public async Task<IActionResult> Index()
        {
            return View(await _context.Igrač.ToListAsync());
        }

        // GET: Igrač/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrač = await _context.Igrač
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrač == null)
            {
                return NotFound();
            }

            return View(igrač);
        }

        // GET: Igrač/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Igrač/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,DatumRođenja")] Igrač igrač)
        {
            if (ModelState.IsValid)
            {
                _context.Add(igrač);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(igrač);
        }

        // GET: Igrač/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrač = await _context.Igrač.FindAsync(id);
            if (igrač == null)
            {
                return NotFound();
            }
            return View(igrač);
        }

        // POST: Igrač/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,DatumRođenja")] Igrač igrač)
        {
            if (id != igrač.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(igrač);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IgračExists(igrač.Id))
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
            return View(igrač);
        }

        // GET: Igrač/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrač = await _context.Igrač
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrač == null)
            {
                return NotFound();
            }

            return View(igrač);
        }

        // POST: Igrač/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var igrač = await _context.Igrač.FindAsync(id);
            _context.Igrač.Remove(igrač);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IgračExists(int id)
        {
            return _context.Igrač.Any(e => e.Id == id);
        }
    }
}
