using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shooping.Data;
using Vereyon.Web;

namespace Shooping.Controllers
{
    public class Suplidores : Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;

        public Suplidores(DataContext context , IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
        }

        public async Task<IActionResult> Index()
        {
            await _context.Suplidores.ToListAsync();
            return View();
        }
    }
}
