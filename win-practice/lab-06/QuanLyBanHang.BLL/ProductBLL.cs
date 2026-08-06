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
            if (_productDAL.GetAll().Any(x => x.MaSP == product.MaSP))
                throw new Exception("Mã sản phẩm đã tồn tại.");

            _productDAL.Add(product);
        }

        public void Update(Product product)
        {
            if (_productDAL.GetAll().Any(x =>
                x.MaSP == product.MaSP &&
                x.Id != product.Id))
            {
                throw new Exception("Mã sản phẩm đã tồn tại.");
            }
            _productDAL.Update(product);
        }

        public void Delete(Product product)
        {
            _productDAL.Delete(product);
        }
    }
}