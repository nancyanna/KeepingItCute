﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeepingItCute.Models;

namespace KeepingItCute.Controllers
{
    public class StylesController : Controller
    {
        private readonly KeepingContext _context;

        public StylesController(KeepingContext context)
        {
            _context = context;
        }

        // GET: Styles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Style.ToListAsync());
        }

        // GET: Styles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _context.Style
                .FirstOrDefaultAsync(m => m.Id == id);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // GET: Styles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Styles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Style style)
        {
            if (ModelState.IsValid)
            {
                _context.Add(style);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(style);
        }

        // GET: Styles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _context.Style.FindAsync(id);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        // POST: Styles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Style style)
        {
            if (id != style.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(style);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StyleExists(style.Id))
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
            return View(style);
        }

        // GET: Styles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _context.Style
                .FirstOrDefaultAsync(m => m.Id == id);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // POST: Styles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var style = await _context.Style.FindAsync(id);
            _context.Style.Remove(style);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StyleExists(int id)
        {
            return _context.Style.Any(e => e.Id == id);
        }
    }
}
