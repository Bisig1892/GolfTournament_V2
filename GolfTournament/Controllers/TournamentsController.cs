using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfTournament.Data;
using GolfTournament.Models;
using GolfTournament.ViewModels;

namespace GolfTournament.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly TournamentContext _context;

        public TournamentsController(TournamentContext context)
        {
            _context = context;
        }

        // GET: Tournaments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tournaments.ToListAsync());
        }

        // GET: Tournaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournaments = await _context.Tournaments
                .FirstOrDefaultAsync(m => m.TournamentId == id);
            if (tournaments == null)
            {
                return NotFound();
            }

            return View(tournaments);
        }

        // GET: Tournaments/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TournamentId,Name,ScheduledDate,Course,Flights")] Tournaments tournaments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournaments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tournaments);
        }

        // GET: Tournaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournaments = await _context.Tournaments.FindAsync(id);
            if (tournaments == null)
            {
                return NotFound();
            }
            return View(tournaments);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TournamentId,Name,ScheduledDate,Flights")] Tournaments tournaments)
        {
            if (id != tournaments.TournamentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournaments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentsExists(tournaments.TournamentId))
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
            return View(tournaments);
        }

        // GET: Tournaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournaments = await _context.Tournaments
                .FirstOrDefaultAsync(m => m.TournamentId == id);
            if (tournaments == null)
            {
                return NotFound();
            }

            return View(tournaments);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournaments = await _context.Tournaments.FindAsync(id);
            _context.Tournaments.Remove(tournaments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentsExists(int id)
        {
            return _context.Tournaments.Any(e => e.TournamentId == id);
        }
    }
}
