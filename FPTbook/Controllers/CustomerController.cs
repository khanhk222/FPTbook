using FPTBook.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FPTbook.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context; 
        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            return View(context.Books.ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(context.Books.Find(id));
        }

        public IActionResult Profile()
        {

        }
    }
}
