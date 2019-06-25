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
    /// <summary>
    /// Classe de controle de endereço de empressas
    /// </summary>
    public class AddressCompaniesController : Controller
    {
        private readonly UnBCineFlixContext _context;

        /// <summary>
        /// ControladorDeEnderecoDasCompanhias
        /// </summary>
        /// <param name="context"></param>
        public AddressCompaniesController(UnBCineFlixContext context)
        {
            _context = context;
        }

        // GET: AddressCompanies
        /// <summary>
        /// 
        /// Tarefa de indexacao
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var unBCineFlixContext = _context.AddressCompanies.Include(a => a.Company);
            return View(await unBCineFlixContext.ToListAsync());
        }

        // GET: AddressCompanies/Details/5
        /// <summary>
        /// Detalhes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressCompany = await _context.AddressCompanies
                .Include(ac => ac.Company)
                .FirstOrDefaultAsync(ac => ac.Id == id);
            //select * from addresses, companies where addresses.Id = id and companies.addressCompanyId = id;
            if (addressCompany == null)
            {
                return NotFound();
            }

            return View(addressCompany);
        }

        // GET: AddressCompanies/Create
        /// <summary>
        /// Criacao inteligencia artificial
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        // POST: AddressCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Criacao em HTTP
        /// </summary>
        /// <param name="addressCompany"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,State,City,District,Street,Number,ZipCode,Complement,CompanyId,Name")] AddressCompany addressCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", addressCompany.CompanyId);
            return View(addressCompany);
        }

        // GET: AddressCompanies/Edit/5
        /// <summary>
        /// Funcao de editar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressCompany = await _context.AddressCompanies.FindAsync(id);
            if (addressCompany == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", addressCompany.CompanyId);
            return View(addressCompany);
        }

        // POST: AddressCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Funcao de editar no HTTP
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressCompany"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,State,City,District,Street,Number,ZipCode,Complement,CompanyId,Name")] AddressCompany addressCompany)
        {
            if (id != addressCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressCompanyExists(addressCompany.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", addressCompany.CompanyId);
            return View(addressCompany);
        }

        // GET: AddressCompanies/Delete/5
        /// <summary>
        /// Funcao de Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressCompany = await _context.AddressCompanies
                .Include(a => a.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressCompany == null)
            {
                return NotFound();
            }

            return View(addressCompany);
        }

        // POST: AddressCompanies/Delete/5
        /// <summary>
        /// Funcao de Deletar em HTTP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressCompany = await _context.AddressCompanies.FindAsync(id);
            _context.AddressCompanies.Remove(addressCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressCompanyExists(int id)
        {
            return _context.AddressCompanies.Any(e => e.Id == id);
        }
    }
}
