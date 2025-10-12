using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities; // Siguraduhing kasama ito
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop_SOLOLEVELING.Controllers
{
    [Authorize]
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IShoeRepository _shoeRepository;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService, ISupplierRepository supplierRepository, IShoeRepository shoeRepository)
        {
            _purchaseOrderService = purchaseOrderService;
            _supplierRepository = supplierRepository;
            _shoeRepository = shoeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var purchaseOrders = await _purchaseOrderService.GetAllPurchaseOrdersAsync();
            return View(purchaseOrders);
        }

        public async Task<IActionResult> Create()
        {
            // Kinukuha ang listahan mula sa repository
            var suppliers = await _supplierRepository.GetAllAsync();
            var shoes = await _shoeRepository.GetAllShoesAsync();

            // Ginagawang SelectList para sa Supplier dropdown
            ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");

            // Ipinapasa ang buong listahan ng shoes para sa JavaScript
            ViewBag.Shoes = shoes;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePurchaseOrderDto purchaseOrderDto)
        {
            purchaseOrderDto.Items?.RemoveAll(i => i.Quantity <= 0 || i.ShoeId == 0 || i.UnitPrice <= 0);

            if (ModelState.IsValid && (purchaseOrderDto.Items?.Any() ?? false))
            {
                await _purchaseOrderService.CreatePurchaseOrderAsync(purchaseOrderDto);
                return RedirectToAction(nameof(Index));
            }

            if (!(purchaseOrderDto.Items?.Any() ?? false))
            {
                ModelState.AddModelError("", "Please add at least one item to the purchase order.");
            }

            // Muling i-populate ang dropdowns kapag may error sa validation
            ViewBag.Suppliers = new SelectList(await _supplierRepository.GetAllAsync(), "Id", "Name", purchaseOrderDto.SupplierId);
            ViewBag.Shoes = await _shoeRepository.GetAllShoesAsync();
            return View(purchaseOrderDto);
        }
    }
}