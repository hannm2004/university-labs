using System;
namespace Webbanhang_NguyenMinhHan.Models
{

    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}