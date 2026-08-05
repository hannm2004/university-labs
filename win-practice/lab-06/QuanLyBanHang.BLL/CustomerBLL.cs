using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.BLL
{
    public class CustomerBLL
    {
        private readonly CustomerDAL _customerDAL = new CustomerDAL();

        public List<Customer> GetAll()
        {
            return _customerDAL.GetAll();
        }

        public void Add(Customer customer)
        {
            _customerDAL.Add(customer);
        }

        public void Update(Customer customer)
        {
            _customerDAL.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDAL.Delete(customer);
        }
    }
}