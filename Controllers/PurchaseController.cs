using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x=>x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list=db.Products.Select(x=>x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Purchase p=db.Purchases.Where(x=>x.id==id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName=new SelectList(list);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id ,Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            p.Purchase_date = pur.Purchase_date;
            p.Purchase_prod= pur.Purchase_prod;
            p.Purchase_qnty= pur.Purchase_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }
}