using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var objItemList = _db.Items.ToList();
            IEnumerable<Item> objItemList = _db.Items;
            return View(objItemList);
        }



        //Create - GET
        public IActionResult Create()
        {
            return View();
        }

        //Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        //Edit - GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            var itemFromDb = _db.Items.Find(id);


            if (itemFromDb==null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }

        //Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item obj)
        {
            

            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
