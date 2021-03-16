using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfTournament.Data;
using GolfTournament.Models;

namespace GolfTournament.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly TournamentContext _context;

        public SponsorsController(TournamentContext context)
        {
            _context = context;
        }

        // GET: Sponsors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sponsors.ToListAsync());
        }

        // GET: Sponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsors = await _context.Sponsors
                .FirstOrDefaultAsync(m => m.SponsorsId == id);
            if (sponsors == null)
            {
                return NotFound();
            }

            return View(sponsors);
        }

        // GET: Sponsors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SponsorsId,Name")] Sponsors sponsors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponsors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsors);
        }

        // GET: Sponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsors = await _context.Sponsors.FindAsync(id);
            if (sponsors == null)
            {
                return NotFound();
            }
            return View(sponsors);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SponsorsId,Name")] Sponsors sponsors)
        {
            if (id != sponsors.SponsorsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorsExists(sponsors.SponsorsId))
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
            return View(sponsors);
        }

        // GET: Sponsors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsors = await _context.Sponsors
                .FirstOrDefaultAsync(m => m.SponsorsId == id);
            if (sponsors == null)
            {
                return NotFound();
            }

            return View(sponsors);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsors = await _context.Sponsors.FindAsync(id);
            _context.Sponsors.Remove(sponsors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorsExists(int id)
        {
            return _context.Sponsors.Any(e => e.SponsorsId == id);
        }
    }
}
