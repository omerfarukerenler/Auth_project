using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auth_project.Models;

namespace Auth_project.Controllers
{
    public class PasswordController : Controller
    {
        private readonly PasswordDBContext _context;

        public PasswordController(PasswordDBContext context)
        {
            _context = context;
        }

        // GET: Password
        public async Task<IActionResult> Index()
        {
            return View(await _context.PasswordTables.ToListAsync());
        }

        
     

        // GET: Password/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Password/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteName,KullaniciAdi,Sifre")] PasswordTable passwordTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwordTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passwordTable);
        }

        // GET: Password/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordTable = await _context.PasswordTables.FindAsync(id);
            if (passwordTable == null)
            {
                return NotFound();
            }
            return View(passwordTable);
        }

        // POST: Password/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteName,KullaniciAdi,Sifre")] PasswordTable passwordTable)
        {
            if (id != passwordTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passwordTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordTableExists(passwordTable.Id))
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
            return View(passwordTable);
        }

        // GET: Password/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordTable = await _context.PasswordTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passwordTable == null)
            {
                return NotFound();
            }

            return View(passwordTable);
        }

        // POST: Password/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passwordTable = await _context.PasswordTables.FindAsync(id);
            _context.PasswordTables.Remove(passwordTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasswordTableExists(int id)
        {
            return _context.PasswordTables.Any(e => e.Id == id);
        }
    }
}
