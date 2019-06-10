using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnBCineFlix.DAL;
using UnBCineFlix.Models;

namespace UnBCineFlixMVC.Controllers
{
    public class MovieTheatersController : Controller
    {
        private readonly UnBCineFlixContext _context;

        public MovieTheatersController(UnBCineFlixContext context)
        {
            _context = context;
        }

        // GET: MovieTheaters
        public async Task<IActionResult> Index()
        {
            var unBCineFlixContext = _context.MovieTheaters.Include(m => m.AddressCompany);
            return View(await unBCineFlixContext.ToListAsync());
        }

        // GET: MovieTheaters/Details/5
        public async Task<IActionResult> Details(int addressCompanyId, int movieTheaterNumber)
        {
            ViewData["mensage"] = TempData["mensage"];
            var movieTheater = new MovieTheater(await _context.MovieTheaters
                .Include(m => m.Chairs)
                .Include(m => m.AddressCompany)
                .FirstOrDefaultAsync(m => (m.MovieTheaterNumber == movieTheaterNumber && m.AddressCompanyId == addressCompanyId)));
            if (movieTheater == null)
            {
                return NotFound();
            }

            return View(movieTheater);
        }

        // GET: MovieTheaters/Create
        public IActionResult Create()
        {
            ViewData["erro"] = TempData["erro"];
            ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name");
            return View();
        }

        // POST: MovieTheaters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieTheaterNumber,Number,QtdRow,QtdCol,AddressCompanyId")] MovieTheater movieTheater)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(movieTheater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    Debug.Write(e);
                    return RedirectToAction(nameof(Create));
                }
                catch (DbUpdateException e)
                {
                    Debug.Write(e);
                    TempData["erro"] = "Already exist, try another";
                    return RedirectToAction(nameof(Create));
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name", movieTheater.AddressCompanyId);
            return View(movieTheater);
        }

        public async Task<IActionResult> CreateChair(int addressCompanyId, int movieTheaterNumber)
        {
            var movieTheater = await _context.MovieTheaters
                .FirstOrDefaultAsync(m=>(m.MovieTheaterNumber==movieTheaterNumber && m.AddressCompanyId == addressCompanyId));
            if (movieTheater == null)
            {
                return NotFound();
            }
            ViewData["erro"] = TempData["erro"];
            ViewData["mensage"] = TempData["mensage"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChair([Bind("MovieTheaterNumber,AddressCompanyId,Row,Col")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var movieTheater = new MovieTheater(await _context.MovieTheaters
                        .Include(m => m.Chairs)
                        .FirstOrDefaultAsync(m => (m.AddressCompanyId == chair.AddressCompanyId && m.MovieTheaterNumber == chair.MovieTheaterNumber)));
                    movieTheater.AddChair(chair);
                    _context.Add(chair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    Debug.Write(e);
                    TempData["erro"] = e.Message;
                    return RedirectToAction(nameof(CreateChair), new { chair.AddressCompanyId, chair.MovieTheaterNumber });
                }
                catch (ArgumentException e)
                {
                    Debug.Write(e);
                    TempData["erro"] = e.Message;
                    return RedirectToAction(nameof(CreateChair), new { chair.AddressCompanyId, chair.MovieTheaterNumber });
                }
                TempData["mensage"] = "Chair Create Success";
                return RedirectToAction(nameof(Details), new { chair.AddressCompanyId, chair.MovieTheaterNumber });
            }
            //ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name", movieTheater.AddressCompanyId);
            return View();
        }

        // GET: MovieTheaters/Edit/5
        public async Task<IActionResult> Edit(int addressCompanyId, int movieTheaterNumber)
        {
            var movieTheater = await _context.MovieTheaters
                .Include(m => m.AddressCompany)
                .FirstOrDefaultAsync(m => (m.MovieTheaterNumber == movieTheaterNumber && m.AddressCompanyId == addressCompanyId));
            if (movieTheater == null)
            {
                return NotFound();
            }
            ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name", movieTheater.AddressCompanyId);
            return View(movieTheater);
        }

        // POST: MovieTheaters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int addressCompanyId, int movieTheaterNumber, [Bind("MovieTheaterNumber,QtdRow,QtdCol,AddressCompanyId")] MovieTheater movieTheater)
        {
            if (addressCompanyId != movieTheater.AddressCompanyId && movieTheaterNumber != movieTheater.MovieTheaterNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieTheater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieTheaterExists(movieTheater.AddressCompanyId, movieTheater.MovieTheaterNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new Exception("Impossible to Update");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name", movieTheater.AddressCompanyId);
            return View(movieTheater);
        }

        // GET: MovieTheaters/Delete/5
        public async Task<IActionResult> Delete(int addressCompanyId, int? movieTheaterNumber)
        {
            var movieTheater = await _context.MovieTheaters
                .Include(m => m.AddressCompany)
                .FirstOrDefaultAsync(m => (m.MovieTheaterNumber == movieTheaterNumber && m.AddressCompanyId == addressCompanyId));
            if (movieTheater == null)
            {
                return NotFound();
            }

            return View(movieTheater);
        }

        public async Task<IActionResult> DeleteChair(int addressCompanyId, int? movieTheaterNumber, int row, int col)
        {
            var chair = _context.Chairs
                .FirstOrDefault(c=> 
                (c.AddressCompanyId == addressCompanyId && 
                c.MovieTheaterNumber == movieTheaterNumber && 
                c.Row == row && c.Col == col));
            if (chair == null)
            {
                return NotFound();
            }
            return View(chair);
        }

        // POST: MovieTheaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int addressCompanyId, int movieTheaterNumber)
        {
            var movieTheater = await _context.MovieTheaters
                .Include(m => m.AddressCompany)
                .FirstOrDefaultAsync(m => (m.MovieTheaterNumber == movieTheaterNumber && m.AddressCompanyId == addressCompanyId));
            _context.MovieTheaters.Remove(movieTheater);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DeleteChair")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChairConfirmed(int addressCompanyId, int movieTheaterNumber, int row, int col)
        {
            var chair = _context.Chairs
                .FirstOrDefault(c =>
                (c.AddressCompanyId == addressCompanyId &&
                c.MovieTheaterNumber == movieTheaterNumber &&
                c.Row == row && c.Col == col));
            _context.Chairs.Remove(chair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { addressCompanyId, movieTheaterNumber });
        }
        private bool MovieTheaterExists(int addressCompanyId, int movieTheaterNumber)
        {
            return _context.MovieTheaters.Any(e => (e.MovieTheaterNumber == movieTheaterNumber && e.AddressCompanyId == addressCompanyId));
        }


    }
}
