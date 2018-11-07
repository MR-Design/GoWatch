using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoWatch.Data;
using GoWatch.Models;

namespace GoWatch.Controllers
{
    public class GuestListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GuestLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GuestLists.Include(g => g.Event).Include(g => g.Fan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GuestLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestList = await _context.GuestLists
                .Include(g => g.Event)
                .Include(g => g.Fan)
                .FirstOrDefaultAsync(m => m.GuestListID == id);
            if (guestList == null)
            {
                return NotFound();
            }

            return View(guestList);
        }

        // GET: GuestLists/Create
        public IActionResult Create()
        {
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID");
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID");
            return View();
        }

        // POST: GuestLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestListID,FanID,EventID,Going,Arrived")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", guestList.EventID);
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID", guestList.FanID);
            return View(guestList);
        }

        // GET: GuestLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestList = await _context.GuestLists.FindAsync(id);
            if (guestList == null)
            {
                return NotFound();
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", guestList.EventID);
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID", guestList.FanID);
            return View(guestList);
        }

        // POST: GuestLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestListID,FanID,EventID,Going,Arrived")] GuestList guestList)
        {
            if (id != guestList.GuestListID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestListExists(guestList.GuestListID))
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
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", guestList.EventID);
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID", guestList.FanID);
            return View(guestList);
        }

        // GET: GuestLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestList = await _context.GuestLists
                .Include(g => g.Event)
                .Include(g => g.Fan)
                .FirstOrDefaultAsync(m => m.GuestListID == id);
            if (guestList == null)
            {
                return NotFound();
            }

            return View(guestList);
        }

        // POST: GuestLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestList = await _context.GuestLists.FindAsync(id);
            _context.GuestLists.Remove(guestList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestListExists(int id)
        {
            return _context.GuestLists.Any(e => e.GuestListID == id);
        }
    }
}
