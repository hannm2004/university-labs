using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.DAL
{
    public class OrderDAL
    {
        private readonly ApplicationDbContext _context =
    new ApplicationDbContext();

        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ToList();
        }

        public Order? GetById(int id)
        {
            return _context.Orders
                .Include(x => x.OrderDetails)
                .FirstOrDefault(x => x.Id == id);
        }

        public void CreateOrder(Order order)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                foreach (var item in order.OrderDetails)
                {
                    Product? product = _context.Products.Find(item.ProductId);

                    if (product == null)
                        throw new Exception("Không tìm thấy sản phẩm.");

                    if (product.SoLuongTon < item.SoLuong)
                        throw new Exception($"Sản phẩm {product.TenSP} không đủ tồn kho.");

                    product.SoLuongTon -= item.SoLuong;

                    item.DonGiaLucBan = product.DonGia;
                }

                _context.Orders.Add(order);

                _context.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void CancelOrder(int orderId)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                Order? order = _context.Orders
                    .Include(x => x.OrderDetails)
                    .FirstOrDefault(x => x.Id == orderId);

                if (order == null)
                    throw new Exception("Không tìm thấy đơn hàng.");

                foreach (var item in order.OrderDetails)
                {
                    Product? product = _context.Products.Find(item.ProductId);

                    if (product != null)
                    {
                        product.SoLuongTon += item.SoLuong;
                    }
                }

                _context.OrderDetails.RemoveRange(order.OrderDetails);

                _context.Orders.Remove(order);

                _context.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}