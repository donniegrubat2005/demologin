using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demologin.Models;

namespace demologin.Controllers
{
    public class HomeController : Controller
    {
        private DevDBContext dbemployee = new DevDBContext();

        public ActionResult Index()
        {
            return View(GetEmployee());
        }

       IEnumerable<Employee> GetEmployee() 
        {
            return dbemployee.Employees.ToList<Employee>();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try { 

            dbemployee.Employees.Add(emp);
            dbemployee.SaveChanges();
                return RedirectToAction("Index");
            } catch

            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(dbemployee.Employees.Where(x => x.Id == id).SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                dbemployee.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                dbemployee.SaveChanges();
                return RedirectToAction("Index");

            } catch
            {
                return View();
            }

            
        }

        public ActionResult Details(int id)
        {
            return View(dbemployee.Employees.Where(x => x.Id == id).SingleOrDefault());
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Employee emp = dbemployee.Employees.Where(x => x.Id == id).SingleOrDefault();
                dbemployee.Employees.Remove(emp);
                dbemployee.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           
        }
    }
}