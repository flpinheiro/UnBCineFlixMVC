using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnBCineFlix.DAL;
using UnBCineFlix.Models;

namespace UnBCineFlixMVC.Controllers
{
    public class SessionsController : Controller
    {
        private readonly UnBCineFlixContext _context;

        public SessionsController(UnBCineFlixContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var unBCineFlixContext = 
                _context.Session.
                Include(s => s.Movie).
                Include(s => s.MovieTheater).ThenInclude(mt=>mt.AddressCompany).ThenInclude(ac=>ac.Company);
            return View(await unBCineFlixContext.ToListAsync());
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .Include(s => s.Movie)
                .Include(s => s.MovieTheater).ThenInclude(mt=>mt.AddressCompany).ThenInclude(ac=>ac.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["AddressCompanyId"] = new SelectList(_context.MovieTheaters, "AddressCompanyId", "AddressCompanyId");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddressCompanyId,MovieTheaterNumber,MovieId,SessionTime")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", session.MovieId);
            ViewData["AddressCompanyId"] = new SelectList(_context.MovieTheaters, "AddressCompanyId", "AddressCompanyId", session.AddressCompanyId);
            return View(session);
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", session.MovieId);
            ViewData["AddressCompanyId"] = new SelectList(_context.MovieTheaters, "AddressCompanyId", "AddressCompanyId", session.AddressCompanyId);
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddressCompanyId,MovieTheaterNumber,MovieId,SessionTime")] Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", session.MovieId);
            ViewData["AddressCompanyId"] = new SelectList(_context.MovieTheaters, "AddressCompanyId", "AddressCompanyId", session.AddressCompanyId);
            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                //.Include(s => s.Movie)
                //.Include(s => s.MovieTheater)
                .Include(s=>s.Tickets)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Session.FindAsync(id);
            _context.Session.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Session.Any(e => e.Id == id);
        }
    }
}
