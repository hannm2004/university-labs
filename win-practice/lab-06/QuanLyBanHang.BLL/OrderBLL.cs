using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL _orderDAL = new OrderDAL();

        public List<Order> GetAll()
        {
            return _orderDAL.GetAll();
        }

        public void CreateOrder(Order order)
        {
            _orderDAL.CreateOrder(order);
        }

        public void CancelOrder(int orderId)
        {
            _orderDAL.CancelOrder(orderId);
        }
    }
}