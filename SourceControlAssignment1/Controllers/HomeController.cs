using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationValidationFinSub.Models;

namespace DataAnnotationValidationFinSub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BookRegistration(BookCatalogModel b)
        {
            if (string.IsNullOrEmpty(b.Name))
            {
                ModelState.AddModelError("Name", "Name is Required");
            }
            if (string.IsNullOrEmpty(b.ISBN) || b.ISBN.Length != 13)
            {
                ModelState.AddModelError("ISBN", "13 Digit ISBN is Required");
            }
            if (string.IsNullOrEmpty(b.LocCode))
            {
                ModelState.AddModelError("LocCode", "Location Code is Required");
            }
            if (ModelState.IsValid)
            {
                ViewBag.Name = b.Name;
                ViewBag.ISBN = b.ISBN;
                ViewBag.LocCode = b.LocCode;
                return View("Index");
            }
            else
                return View("Index");
        }
    }
}