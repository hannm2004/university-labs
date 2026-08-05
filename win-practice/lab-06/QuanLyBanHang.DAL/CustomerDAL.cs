using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.DAL
{
    public class CustomerDAL
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}