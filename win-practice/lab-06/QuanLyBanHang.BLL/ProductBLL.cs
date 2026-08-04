using QuanLyBanHang.DAL.Entities;

public class ProductBLL
{
    private readonly ProductDAL _productDAL = new ProductDAL();

    public List<Product> GetAll()
    {
        return _productDAL.GetAll();
    }

    public void Add(Product p)
    {
        _productDAL.Add(p);
    }

    public void Update(Product p)
    {
        _productDAL.Update(p);
    }

    public void Delete(Product p)
    {
        _productDAL.Delete(p);
    }
}