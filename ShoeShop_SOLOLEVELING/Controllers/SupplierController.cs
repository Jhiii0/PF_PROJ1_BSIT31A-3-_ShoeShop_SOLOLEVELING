using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities;
using System.Threading.Tasks;

namespace ShoeShop_SOLOLEVELING.Controllers
{
    [Authorize] // Para lang sa mga naka-log in
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        // GET: /Supplier
        // Ito ang magpapakita ng listahan ng lahat ng suppliers
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return View(suppliers);
        }

        // GET: /Supplier/Create
        // Ito ang magpapakita ng form para gumawa ng bagong supplier
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Supplier/Create
        // Ito ang magpo-proseso ng data mula sa form at isasave ito
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.IsActive = true; // Set default value
                await _supplierRepository.AddSupplierAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
    }
}