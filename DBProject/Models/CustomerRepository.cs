﻿using DBProject.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;

namespace DBProject.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private GSContext _context;
        public CustomerRepository(GSContext context) 
        { 
            _context = context;
        } 
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList(); 
            //IEnumerable<Customer> customers = _context.Customers;
            //IEnumerable<Customer> tempList = customers.Where(c=>c.Id==20).ToList<Customer>();
            //return tempList.ToList();
            //IQueryable<Customer> cust = _context.Customers.Where(c => c.Id == 25);

            //IQueryable<Customer> cust = _context.Customers.Where(c => c.City == "London").Take(2).OrderBy(c => c.LastName);

            //IQueryable<Customer> cust = _context.Customers.Select(* Where(c => c.City == "London");
            // System.Linq.IQueryable<string> name = _context.Customers.AsNoTracking().Select(c => c.FirstName));

            //return cust.ToList();   
        }

        public Customer GetCustomerById(int CustomerID)
        {
            return _context.Customers.Find(CustomerID);
        }
        public Customer Update(Customer customer)
        {
            var c = _context.Customers.Attach(customer);
            c.State= EntityState.Modified;  
            _context.SaveChanges();
            return customer;
        }
    }
}
