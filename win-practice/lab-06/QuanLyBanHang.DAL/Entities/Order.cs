namespace QuanLyBanHang.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime NgayDat { get; set; }

        public string TrangThai { get; set; } = "Đang xử lý";

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}