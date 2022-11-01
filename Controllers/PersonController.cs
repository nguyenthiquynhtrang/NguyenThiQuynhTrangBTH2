using NguyenThiQuynhTrangBTH2.Data;
using NguyenThiQuynhTrangBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NguyenThiQuynhTrangBTH2.Controllers
{
    public class PersonController : Controller
    {
        //khai bao DBcontext de lam viec voi Database
        private readonly ApplicationDbContext _context;
        public PersonController (ApplicationDbContext context)
        {
            _context = context;
        }
        // Action tra ve View hien thi danh sach 
        public async Task<IActionResult> Index()
        {
            var model = await _context.Persons.ToListAsync();
            return View(model);
        }
        //Action tra ve View them moi danh sach 
        public IActionResult Create()
        {
            return View();
        }
        //Action xu ly du lieu gui len tu view va luu vao Database
        [HttpPost]
        public async Task<IActionResult> Create(Person std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(std);
        }
         //GET: Person/Edit/5
     public async Task<IActionResult> Edit(string id)
     {
        if(id == null)
        {
            return View("NotFound");
        }
        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            return View("NotFound");
        }
        return View(person);
     }
       //POST :Student/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName")] Person std)
    {
        if (id !=std.PersonID)
        {
            return View("NotFound");
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(std);
                await _context.SaveChangesAsync();
            }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(std.PersonID))
            {
                return View("NotFound");
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
        }
        return View(std);
    }
    //GET: Person/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return View("NotFound");
        }
        var std = await _context.Persons
         .FirstOrDefaultAsync(m => m.PersonID == id);
        if (std == null)
        {
            return View("NotFound");
        }
        return View(std);
    }
    //POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var std = await _context.Persons.FindAsync(id);
        _context.Persons.Remove(std);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool PersonExists(string id)
    {
        return _context.Persons.Any(e => e.PersonID == id);
    }
    }
}

    
