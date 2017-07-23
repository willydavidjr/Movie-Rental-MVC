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
            string value = "01-01-1985";
            object objectValue = (string)value;
            string dt = DateTime.Now.ToShortDateString();

            DateTime time;
            var isvalid = DateTime.TryParseExact(Convert.ToString   (value), System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out time);

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel model) //UpdateCustomerDto model
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = model.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (model.Customer.Id == 0)
                _context.Customers.Add(model.Customer);
            else
            {
                //We can use AutoMapper:
                //Mapper.Map(model, customeriDB);
                var customerInDB = _context.Customers.SingleOrDefault(item => item.Id == model.Customer.Id);
                customerInDB.MembershipTypeId = model.Customer.MembershipTypeId;
                customerInDB.BirthDate = model.Customer.BirthDate;
                customerInDB.Name = model.Customer.Name;
                customerInDB.IsSubscribeToNewsletter = model.Customer.IsSubscribeToNewsletter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Details (int CustomerID)
        {
            //Customer cust = GetCustomers().Where(x => x.Id == CustomerID).SingleOrDefault();
            Customer cust = _context.Customers.Where(x => x.Id == CustomerID).SingleOrDefault();
            if (cust == null)
                return HttpNotFound();
            return View(cust);
        }

        public ActionResult Edit(int CustomerID)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerID);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
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