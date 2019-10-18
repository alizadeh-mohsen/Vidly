using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<Customer> customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            ModifyCustomerViewModel model = new ModifyCustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("ModifyCustomer", model);
        }

        public ActionResult Edit(int id)
        {
            ModifyCustomerViewModel model = new ModifyCustomerViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c => c.Id == id),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("ModifyCustomer", model);
        }
        [HttpPost]
        public ActionResult Save(ModifyCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModifyCustomerViewModel modifyCustomerViewModel = new ModifyCustomerViewModel
                {
                    Customer = model.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("ModifyCustomer", modifyCustomerViewModel);
            }
            if (model.Customer.Id.Equals(0))
            {
                byte discountRate = 0;
                if (model.Customer.MembershipTypeId.Equals(1))
                    discountRate = 0;
                if (model.Customer.MembershipTypeId.Equals(2))
                    discountRate = 10;
                if (model.Customer.MembershipTypeId.Equals(3))
                    discountRate = 15;
                if (model.Customer.MembershipTypeId.Equals(4))
                    discountRate = 20;

                model.Customer.DiscountRate = discountRate;
                _context.Customers.Add(model.Customer);

            }
            else
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == model.Customer.Id);
                customer.MembershipTypeId = model.Customer.MembershipTypeId;
                customer.Birthday = model.Customer.Birthday;
                customer.Name = model.Customer.Name;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}