namespace QuanLyBanHang.GUI.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }

        public string MaSP { get; set; } = string.Empty;

        public string TenSP { get; set; } = string.Empty;

        public decimal DonGiaLucBan { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien
        {
            get
            {
                return DonGiaLucBan * SoLuong;
            }
        }
    }
}