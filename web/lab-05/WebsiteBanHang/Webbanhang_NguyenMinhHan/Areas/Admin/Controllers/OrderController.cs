using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbanhang_NguyenMinhHan.Models;
using Webbanhang_NguyenMinhHan.Repositories;

namespace Webbanhang_NguyenMinhHan.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Danh sách đơn hàng
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
            return View(orders);
        }

        // Chi tiết đơn hàng
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // Xóa đơn hàng
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}