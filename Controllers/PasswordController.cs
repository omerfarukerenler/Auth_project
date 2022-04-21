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

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.PasswordTables.ToListAsync());
        }


        public async  Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var passwordTable = await _context.PasswordTables.FirstOrDefaultAsync(m => m.Id == id);
            if(passwordTable == null)
            {
                return NotFound();
            }
            return View(passwordTable);
        }
        
     

        
        public async Task<IActionResult> Create(int id = 0)
        {
            if(id == 0)
            return View();
            else
            {

                var passwordTable = await _context.PasswordTables.FindAsync(id);
                if (passwordTable == null)
                {
                    return NotFound();
                }
                return View(passwordTable);

            }
        }





       
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
