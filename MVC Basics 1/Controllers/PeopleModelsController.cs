using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;

namespace MVC_Basics_1.Controllers
{
    public class PeopleModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PeopleModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.People.Include(p => p.City);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PeopleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.People
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (peopleModel == null)
            {
                return NotFound();
            }

            return View(peopleModel);
        }

        // GET: PeopleModels/Create
        public IActionResult Create()
        {
            ViewData["CityID"] = new SelectList(_context.Cities, "ID", "CountryCode");
            return View();
        }

        // POST: PeopleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,PhoneNumber,Email,CityID")] PeopleModel peopleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peopleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "ID", "CountryCode", peopleModel.CityID);
            return View(peopleModel);
        }

        // GET: PeopleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.People.FindAsync(id);
            if (peopleModel == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "ID", "CountryCode", peopleModel.CityID);
            return View(peopleModel);
        }

        // POST: PeopleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FullName,PhoneNumber,Email,CityID")] PeopleModel peopleModel)
        {
            if (id != peopleModel.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peopleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleModelExists(peopleModel.PersonId))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "ID", "CountryCode", peopleModel.CityID);
            return View(peopleModel);
        }

        // GET: PeopleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.People
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (peopleModel == null)
            {
                return NotFound();
            }

            return View(peopleModel);
        }

        // POST: PeopleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peopleModel = await _context.People.FindAsync(id);
            _context.People.Remove(peopleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleModelExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
