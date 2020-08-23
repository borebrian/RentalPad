using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;
using RentalPad.Models;

namespace RentalPad.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TenantsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenants.ToListAsync());
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenants = await _context.Tenants
                .FirstOrDefaultAsync(m => m.National_id == id);
            if (tenants == null)
            {
                return NotFound();
            }

            return View(tenants);
        }

        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("National_id,Full_names,Phone_number,Location,Start_date,End_date,Rental_reg")] Tenants tenants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenants);
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenants = await _context.Tenants.FindAsync(id);
            if (tenants == null)
            {
                return NotFound();
            }
            return View(tenants);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("National_id,Full_names,Phone_number,Location,Start_date,End_date,Rental_reg")] Tenants tenants)
        {
            if (id != tenants.National_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantsExists(tenants.National_id))
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
            return View(tenants);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenants = await _context.Tenants
                .FirstOrDefaultAsync(m => m.National_id == id);
            if (tenants == null)
            {
                return NotFound();
            }

            return View(tenants);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenants = await _context.Tenants.FindAsync(id);
            _context.Tenants.Remove(tenants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantsExists(int id)
        {
            return _context.Tenants.Any(e => e.National_id == id);
        }
    }
}
