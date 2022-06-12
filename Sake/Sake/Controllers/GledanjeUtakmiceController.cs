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
    public class GledanjeUtakmiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GledanjeUtakmiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GledanjeUtakmice
        public async Task<IActionResult> Index()
        {
            return View(await _context.GledanjeUtakmice.ToListAsync());
        }

        // GET: GledanjeUtakmice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gledanjeUtakmice = await _context.GledanjeUtakmice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gledanjeUtakmice == null)
            {
                return NotFound();
            }

            return View(gledanjeUtakmice);
        }

        // GET: GledanjeUtakmice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GledanjeUtakmice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUtakmice,DostupanLivestream")] GledanjeUtakmice gledanjeUtakmice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gledanjeUtakmice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gledanjeUtakmice);
        }

        // GET: GledanjeUtakmice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gledanjeUtakmice = await _context.GledanjeUtakmice.FindAsync(id);
            if (gledanjeUtakmice == null)
            {
                return NotFound();
            }
            return View(gledanjeUtakmice);
        }

        // POST: GledanjeUtakmice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUtakmice,DostupanLivestream")] GledanjeUtakmice gledanjeUtakmice)
        {
            if (id != gledanjeUtakmice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gledanjeUtakmice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GledanjeUtakmiceExists(gledanjeUtakmice.Id))
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
            return View(gledanjeUtakmice);
        }

        // GET: GledanjeUtakmice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gledanjeUtakmice = await _context.GledanjeUtakmice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gledanjeUtakmice == null)
            {
                return NotFound();
            }

            return View(gledanjeUtakmice);
        }

        // POST: GledanjeUtakmice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gledanjeUtakmice = await _context.GledanjeUtakmice.FindAsync(id);
            _context.GledanjeUtakmice.Remove(gledanjeUtakmice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GledanjeUtakmiceExists(int id)
        {
            return _context.GledanjeUtakmice.Any(e => e.Id == id);
        }
    }
}
