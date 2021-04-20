using CustomersRegistration.Models;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly Context _context = new Context();

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            try
            {
                var customers = _context.Customers.Include(p => p.Numbers).Include(p => p.Addresses).Include(p => p.SocialMedias);
                return customers;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post(Customer customer)
        {
            try
            {
                var context = new Context();
                context.Add(customer);
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public void Put(Customer customer)
        {
            try
            {
                var context = new Context();
                var customerDB = context.Customers.Where(d => d.idCustomer == customer.idCustomer).AsNoTracking().Include(p => p.Numbers).Include(p => p.Addresses).Include(p => p.SocialMedias).FirstOrDefault();

                var contextDelete = new Context();
                foreach (var item in customerDB.Addresses)
                    if (!customer.Addresses.Any(o => o.idAddress == item.idAddress))
                        contextDelete.Remove(item);

                foreach (var item in customerDB.Numbers)
                    if (!customer.Numbers.Any(o => o.idNumber == item.idNumber))
                        contextDelete.Remove(item);

                foreach (var item in customerDB.SocialMedias)
                    if (!customer.SocialMedias.Any(o => o.idSocialMedia == item.idSocialMedia))
                        contextDelete.Remove(item);

                contextDelete.SaveChangesAsync();

                context.Update(customer);
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
