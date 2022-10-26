using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FPTBook.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //view customer

        [Route("/")]
        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }

        public IActionResult Detail(int id)
        {
            var book = context.Books
                                 .Include(b => b.Category)
                                 .FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        //view admin
        public IActionResult Admin()
        {
            return View(context.Books.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            //lấy ra dữ liệu từ bảng University và lưu vào list
            var categories = context.Categories.ToList();
            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //lấy ra dữ liệu từ bảng University và lưu vào list
            var categories = context.Categories.ToList();
            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;
            return View(context.Categories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                //neu id khong tim thay se tra ve not found
                return NotFound();
            }
            else
            {
                //tim ra object student co id duoc yeu cau
                var book = context.Books.Find(id);
                //xoa object student vua tim thay
                context.Books.Remove(book);
                //luu lai thay doi trong db
                context.SaveChanges();
                //gui thong bao ve trang index
                TempData["Message"] = "Delete successfully";
                //quay tro lai trang index
                return RedirectToAction("Index");
            }
        }
        public IActionResult Search(string keyword)
        {
            //books ma co name co chua keyword chuyen vao giong voi Name trong Database thi se tra lai ra View
            var books = context.Books.Where(b=>b.Name.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No book found";
            }
            return View("Index",books);
        }
        public IActionResult SortASC()
        {
            return View("Index",context.Books.OrderBy(b=>b.Name).ToList());
        }
        public IActionResult SortDSC()
        {
            return View("Index",context.Books.OrderByDescending(b => b.Name).ToList());
        }
    }
}