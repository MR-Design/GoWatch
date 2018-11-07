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
    public class FriendRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FriendRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FriendRequests.Include(f => f.Fan).Include(f => f.Friend);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FriendRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendRequest = await _context.FriendRequests
                .Include(f => f.Fan)
                .Include(f => f.Friend)
                .FirstOrDefaultAsync(m => m.FriendRequestID == id);
            if (friendRequest == null)
            {
                return NotFound();
            }

            return View(friendRequest);
        }

        // GET: FriendRequests/Create
        public IActionResult Create()
        {
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID");
            ViewData["FriendID"] = new SelectList(_context.Fans, "FanID", "FanID");
            return View();
        }

        // POST: FriendRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendRequestID,FanID,FriendID,StatusRequest")] FriendRequest friendRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID", friendRequest.FanID);
            ViewData["FriendID"] = new SelectList(_context.Fans, "FanID", "FanID", friendRequest.FriendID);
            return View(friendRequest);
        }

        // GET: FriendRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendRequest = await _context.FriendRequests.FindAsync(id);
            if (friendRequest == null)
            {
                return NotFound();
            }
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID", friendRequest.FanID);
            ViewData["FriendID"] = new SelectList(_context.Fans, "FanID", "FanID", friendRequest.FriendID);
            return View(friendRequest);
        }

        // POST: FriendRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendRequestID,FanID,FriendID,StatusRequest")] FriendRequest friendRequest)
        {
            if (id != friendRequest.FriendRequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendRequestExists(friendRequest.FriendRequestID))
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
            ViewData["FanID"] = new SelectList(_context.Fans, "FanID", "FanID", friendRequest.FanID);
            ViewData["FriendID"] = new SelectList(_context.Fans, "FanID", "FanID", friendRequest.FriendID);
            return View(friendRequest);
        }

        // GET: FriendRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendRequest = await _context.FriendRequests
                .Include(f => f.Fan)
                .Include(f => f.Friend)
                .FirstOrDefaultAsync(m => m.FriendRequestID == id);
            if (friendRequest == null)
            {
                return NotFound();
            }

            return View(friendRequest);
        }

        // POST: FriendRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(id);
            _context.FriendRequests.Remove(friendRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendRequestExists(int id)
        {
            return _context.FriendRequests.Any(e => e.FriendRequestID == id);
        }
    }
}
