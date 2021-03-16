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
    public class IndividualCompetionsController : Controller
    {
        private readonly TournamentContext _context;

        public IndividualCompetionsController(TournamentContext context)
        {
            _context = context;
        }

        // GET: IndividualCompetions
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndividualCompetions.ToListAsync());
        }

        // GET: IndividualCompetions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualCompetions = await _context.IndividualCompetions
                .FirstOrDefaultAsync(m => m.IndividualCompetionsId == id);
            if (individualCompetions == null)
            {
                return NotFound();
            }

            return View(individualCompetions);
        }

        // GET: IndividualCompetions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndividualCompetions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndividualCompetionsId,FirstName,LastName,Description,PrizeMoney")] IndividualCompetions individualCompetions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individualCompetions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(individualCompetions);
        }

        // GET: IndividualCompetions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualCompetions = await _context.IndividualCompetions.FindAsync(id);
            if (individualCompetions == null)
            {
                return NotFound();
            }
            return View(individualCompetions);
        }

        // POST: IndividualCompetions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndividualCompetionsId,FirstName,LastName,Description,PrizeMoney")] IndividualCompetions individualCompetions)
        {
            if (id != individualCompetions.IndividualCompetionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individualCompetions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividualCompetionsExists(individualCompetions.IndividualCompetionsId))
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
            return View(individualCompetions);
        }

        // GET: IndividualCompetions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualCompetions = await _context.IndividualCompetions
                .FirstOrDefaultAsync(m => m.IndividualCompetionsId == id);
            if (individualCompetions == null)
            {
                return NotFound();
            }

            return View(individualCompetions);
        }

        // POST: IndividualCompetions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var individualCompetions = await _context.IndividualCompetions.FindAsync(id);
            _context.IndividualCompetions.Remove(individualCompetions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividualCompetionsExists(int id)
        {
            return _context.IndividualCompetions.Any(e => e.IndividualCompetionsId == id);
        }
    }
}
