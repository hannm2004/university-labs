namespace QuanLyBanHang.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string HoTen { get; set; } = string.Empty;

        public string SoDienThoai { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; }
            = new List<Order>();
    }
}