﻿using System;
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTheater = await _context.MovieTheaters
                .Include(m => m.AddressCompany)
                .FirstOrDefaultAsync(m => m.AddressCompanyId == id);
            if (movieTheater == null)
            {
                return NotFound();
            }

            return View(movieTheater);
        }

        // GET: MovieTheaters/Create
        public IActionResult Create()
        {
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
                    //throw new DbUpdateConcurrencyException("Impossible to add this Movie Theater");
                }
                catch (DbUpdateException e)
                {
                    Debug.Write(e);
                    //throw new DbUpdateException("Impossible to save",e);
                    return RedirectToAction(nameof(Create));
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name", movieTheater.AddressCompanyId);
            return View(movieTheater);
        }

        // GET: MovieTheaters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTheater = await _context.MovieTheaters.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("MovieTheaterNumber,Number,QtdRow,QtdCol,AddressCompanyId")] MovieTheater movieTheater)
        {
            if (id != movieTheater.AddressCompanyId)
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
                    if (!MovieTheaterExists(movieTheater.AddressCompanyId))
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
            ViewData["AddressCompanyId"] = new SelectList(_context.AddressCompanies, "Id", "Name", movieTheater.AddressCompanyId);
            return View(movieTheater);
        }

        // GET: MovieTheaters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTheater = await _context.MovieTheaters
                .Include(m => m.AddressCompany)
                .FirstOrDefaultAsync(m => m.AddressCompanyId == id);
            if (movieTheater == null)
            {
                return NotFound();
            }

            return View(movieTheater);
        }

        // POST: MovieTheaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieTheater = await _context.MovieTheaters.FindAsync(id);
            _context.MovieTheaters.Remove(movieTheater);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieTheaterExists(int id)
        {
            return _context.MovieTheaters.Any(e => e.AddressCompanyId == id);
        }
    }
}
