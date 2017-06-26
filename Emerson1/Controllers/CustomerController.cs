using Emerson1.Models;
using Emerson1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Emerson1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //IEnumerable<Customer> customers = GetCustomers();  
            IEnumerable<Customer> customers = _context.Customers.Include(inc => inc.MembershipType);
            return View(customers);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Details (int CustomerID)
        {
            //Customer cust = GetCustomers().Where(x => x.Id == CustomerID).SingleOrDefault();
            Customer cust = _context.Customers.Where(x => x.Id == CustomerID).SingleOrDefault();
            if (cust == null)
                return HttpNotFound();
            return View(cust);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            Customer john = new Customer() { Id = 1, Name = "John Paul" };
            Customer mat = new Customer() { Id = 2, Name = "Matthew" };
            List<Customer> customers = new List<Customer>();
            customers.Add(john);
            customers.Add(mat);
            return customers;
        }
    }
}