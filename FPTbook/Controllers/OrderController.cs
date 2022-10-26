using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FPTBook.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add(int id, int quantity)
        {
            Order order = new Order();
            var book = context.Books.Find(id);
            order.Book = book;
            order.BookId = id;
            order.OrderQuantity = quantity;
            order.OrderPrice = book.Price * quantity;
            order.OrderDate = DateTime.Now;
            order.UserEmail = User.Identity.Name;
            context.Orders.Add(order);
            book.Quantity -= quantity;
            context.Books.Update(book);
            context.SaveChanges();
            TempData["Success"] = "Order book successfully !";
            return RedirectToAction("Index", "Customer"); //Tra lai action Index cua bookcontroller
        }
        public IActionResult Detail()
        {
            var book = context.Books.ToList();
            ViewBag.Books = book;
            var order = context.Orders.ToList();
            return View(order);
        }
        public IActionResult Delete(int?id)
        {
            if (id == null)
                return NotFound();
            else
            {
                var order = context.Orders.Find(id);
                context.Orders.Remove(order);
                var book = context.Books.Find(order.BookId);
                book.Quantity += order.OrderQuantity;
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Detail", order); 
            }
        }
    }
}
