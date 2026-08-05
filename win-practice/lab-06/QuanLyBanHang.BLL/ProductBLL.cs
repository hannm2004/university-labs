using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.BLL
{
    public class ProductBLL
    {
        private readonly ProductDAL _productDAL = new ProductDAL();

        public List<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public void Add(Product product)
        {
            _productDAL.Add(product);
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }

        public void Delete(Product product)
        {
            _productDAL.Delete(product);
        }
    }
}