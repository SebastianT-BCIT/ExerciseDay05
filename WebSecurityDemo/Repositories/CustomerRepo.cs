// File: Repositories/CustomerRepo.cs
using Microsoft.EntityFrameworkCore;
using WebSecurityDemo.Data;
using WebSecurityDemo.Models;

namespace WebSecurityDemo.Repositories
{
    public class CustomerRepo
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _db.Customers
                      .OrderBy(c => c.LastName)
                      .ThenBy(c => c.FirstName)
                      .AsNoTracking()
                      .ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _db.Customers
                      .AsNoTracking()
                      .FirstOrDefault(c => c.CustomerId == id);
        }

        public string DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return $"Customer with id {id} not found.";
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return $"Customer {customer.FullName} (Id: {id}) was deleted.";
        }
    }
}
