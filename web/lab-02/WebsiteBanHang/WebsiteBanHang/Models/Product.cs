using System.ComponentModel.DataAnnotations;

namespace WebsiteBanHang.Models
{
    public class Product
    {
        public int Id { get; set; }

        // bắt buộc nhập
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // giá sản phẩm
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

    }
}
