using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id.Equals(id));
            if (customer == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            return customer;
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var newCustomer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + newCustomer.Id), newCustomer);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id.Equals(id));

            if (dbCustomer == null)
            {
                NotFound();
            }
            dbCustomer.Birthday = customer.Birthday;
            dbCustomer.DiscountRate = customer.DiscountRate;
            dbCustomer.MembershipTypeId = customer.MembershipTypeId;
            dbCustomer.Name = customer.Name;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
