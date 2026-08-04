using QuanLyBanHang.DAL.Entities;
using QuanLyBanHang.DAL;

public class ProductDAL
{
    private readonly ApplicationDbContext _context =
        new ApplicationDbContext();

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}