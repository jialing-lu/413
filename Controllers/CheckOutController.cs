using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _413.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _413.Controllers
{
    public class CheckOutController : Controller
    {
        private ICheckOutRepository repo { get; set; }

        private Basket basket { get; set; }

        public CheckOutController(ICheckOutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View(new CheckOut());
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOut checkout)
        {
            IdentitySeedData.num = IdentitySeedData.num + 5;
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckOut(checkout);
                basket.ClearBasket();

                return RedirectToPage("/CheckOutCompleted");
            }
            else
            {
                return View();
            }

            

        }
    }
}
