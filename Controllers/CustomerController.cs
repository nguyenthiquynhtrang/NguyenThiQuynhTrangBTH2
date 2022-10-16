using NguyenThiQuynhTrangBTH2.Data;
using NguyenThiQuynhTrangBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NguyenThiQuynhTrangBTH2.Controllers
{
    public class CustomerController : Controller
    {
        //khai bao DBcontext de lam viec voi Database
        private readonly ApplicationDbContext _context;
        public CustomerController (ApplicationDbContext context)
        {
            _context = context;
        }
        // Action tra ve View hien thi danh sach 
        public async Task<IActionResult> Index()
        {
            var model = await _context.Customers.ToListAsync();
            return View(model);
        }
        //Action tra ve View them moi danh sach 
        public IActionResult Create()
        {
            return View();
        }
        //Action xu ly du lieu gui len tu view va luu vao Database
        [HttpPost]
        public async Task<IActionResult> Create(Customer std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(std);
        }
    }
}