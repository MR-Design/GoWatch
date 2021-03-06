﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoWatch.Data;
using GoWatch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols;
using Stripe;
using Event = GoWatch.Models.Event;

namespace GoWatch.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
               // Amount = _context.Events.Select(x => x.Price).SingleOrDefault(),
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return View();
        }
        public ActionResult SearchEvents(string searchString)
        {
            var Word = _context.Events.ToList();
            var Word2 = _context.Events.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                Word = Word.Where(s => s.AwayTeam.Contains(searchString)).ToList(); // I need to search in the hole database
                Word2 = Word2.Where(s => s.HomeTeam.Contains(searchString)).ToList(); // I need to search in the hole database

            }
            var w = Word;
            Word = Word2;
            return View(w);
        }
        //[HttpGet]
        //public ActionResult Joining()
        //{
        //    return View();
        //}
        public ActionResult Joining(int? id)
        {
            
            var viewModel = new MainViewModel()
            {
                AllFans = new List<Fan>(),
                guestLists =new GuestList()
            };

            var eventIDInDb = _context.Events.Where(s => s.EventID == id).FirstOrDefault();
            viewModel.guestLists.EventID = eventIDInDb.EventID;

            Fan fun = _context.Fans.Where(s => s.ApplicationUserId == User.Identity.GetUserId().ToString()).SingleOrDefault();
            //sfan.ApplicationUserId = User.Identity.GetUserId();
            viewModel.guestLists.FanID = fun.FanID;

            viewModel.guestLists.Going = true;
                _context.GuestLists.Add(viewModel.guestLists);
            _context.SaveChanges();
            return RedirectToAction("index", "Events");
        }

        // GET: Events
        public  ActionResult Index(string searchString)
        {

            var Word = _context.Events.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                Word = Word.Where(s => s.AwayTeam == searchString || s.HomeTeam == searchString).ToList(); // I need to search in the hole database

            }
            return View("Index", Word);
         
        }

        

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventType,Address,City,State,ZipCode,HomeTeam,AwayTeam,Rules,Price")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventType,Address,City,State,ZipCode,HomeTeam,AwayTeam,Rules,Price")] Models.Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
