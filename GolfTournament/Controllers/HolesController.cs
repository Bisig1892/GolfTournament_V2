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
    public class HolesController : Controller
    {
        private readonly TournamentContext _context;

        public HolesController(TournamentContext context)
        {
            _context = context;
        }

        // GET: Holes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Holes.ToListAsync());
        }

        // GET: Holes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holes = await _context.Holes
                .FirstOrDefaultAsync(m => m.HoleId == id);
            if (holes == null)
            {
                return NotFound();
            }

            return View(holes);
        }

        // GET: Holes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Holes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoleId,Number,Par,Handicap")] Holes holes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holes);
        }

        // GET: Holes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holes = await _context.Holes.FindAsync(id);
            if (holes == null)
            {
                return NotFound();
            }
            return View(holes);
        }

        // POST: Holes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoleId,Number,Par,Handicap")] Holes holes)
        {
            if (id != holes.HoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HolesExists(holes.HoleId))
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
            return View(holes);
        }

        // GET: Holes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holes = await _context.Holes
                .FirstOrDefaultAsync(m => m.HoleId == id);
            if (holes == null)
            {
                return NotFound();
            }

            return View(holes);
        }

        // POST: Holes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holes = await _context.Holes.FindAsync(id);
            _context.Holes.Remove(holes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HolesExists(int id)
        {
            return _context.Holes.Any(e => e.HoleId == id);
        }
    }
}
