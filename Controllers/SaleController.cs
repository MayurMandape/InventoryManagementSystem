using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale sa)
        {
            db.Sales.Add(sa);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale sa = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(sa);
        }

        [HttpPost]
        public ActionResult Edit(int id, Sale sla)
        {
            Sale sa = db.Sales.Where(x => x.id == id).SingleOrDefault();
            sa.Sale_date=sla.Sale_date.Date;
            sa.Sale_prod = sla.Sale_prod;
            sa.Sale_qnty=sla.Sale_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult Delete(int id, Sale s)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}