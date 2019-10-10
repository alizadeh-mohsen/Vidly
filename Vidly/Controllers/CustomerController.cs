using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer() {Id= 1,Name = "John Smit"},
                new Customer() {Id = 2,Name = "Mary Williams"},
            };

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer=new Customer();
            if (id == 1)
            {
                customer.Name = "John Smit";
                customer.Id = 1;
            }
            else if (id == 2)
            {
                customer.Name = "Mary Williams";

                customer.Id = 2;
            }
            else
            {
                return new HttpNotFoundResult();
            }

            return View(customer);
        }
    }
}