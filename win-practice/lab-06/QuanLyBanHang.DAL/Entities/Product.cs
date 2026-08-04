namespace QuanLyBanHang.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string MaSP { get; set; } = string.Empty;

        public string TenSP { get; set; } = string.Empty;

        public decimal DonGia { get; set; }

        public int SoLuongTon { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}