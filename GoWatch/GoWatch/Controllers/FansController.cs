using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoWatch.Data;

using System.Security.Claims;
using GoWatch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System;

namespace GoWatch.Controllers
{
    public class FansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fans.Include(f => f.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fans/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var fan = await _context.Fans
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.FanID == id);
            if (fan == null)
            {
                return NotFound();
            }

            return View(fan);
        }

        // GET: Fans/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: Fans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FanID,FavoriteTeam,FirstName,Lastname,Address,ZipCode,City,State")] Fan fan)
        {
            Fan fun = _context.Fans.Where(s => s.ApplicationUserId == User.Identity.GetUserId().ToString()).SingleOrDefault();

            //var ThisUser = _context.Fans.Where(s => s.ApplicationUserId == fan.FanID.ToString()).SingleOrDefault();
            fan.ApplicationUserId = User.Identity.GetUserId();
            
            if (ModelState.IsValid)
            {
                _context.Add(fan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", fan.ApplicationUserId);
            return View(fan);
        }

        // GET: Fans/Edit/5
        public  ActionResult Edit()
        {
           
            var currentUser = User.Identity.GetUserId();
            Fan fans = _context.Fans.Where(s => s.ApplicationUserId == currentUser).SingleOrDefault();
            fans.ApplicationUserId = User.Identity.GetUserId();           
            return View(fans);
        }

        // POST: Fans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( IFormCollection collection)
        {
            var currentUser = User.Identity.GetUserId();
            Fan s = _context.Fans.Where(f => f.ApplicationUserId == currentUser).SingleOrDefault();

            s.Address = collection["Address"];
            s.ZipCode = collection["ZipCode"];
            s.City = collection["City"];
            s.State = collection["State"];
            s.CardholderName = collection["CardholderName"];
            s.CCV = Int32.Parse(collection["CCV"]);
            s.CreditCardNumber = Int32.Parse(collection["CreditCardNumber"]);
            s.ExpirationDate = DateTime.Parse(collection["ExpirationDate"]);



            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }

        // GET: Fans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fan = await _context.Fans
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.FanID == id);
            if (fan == null)
            {
                return NotFound();
            }

            return View(fan);
        }

        // POST: Fans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fan = await _context.Fans.FindAsync(id);
            _context.Fans.Remove(fan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FanExists(int id)
        {
            return _context.Fans.Any(e => e.FanID == id);
        }
    }
}
