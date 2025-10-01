using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        // 1. Missing Method: GetSupplierByIdAsync (ginagamit sa CreateOrderAsync)
        Task<Supplier?> GetSupplierByIdAsync(int supplierId);

        // 2. Missing Method: GetAllSuppliersAsync (ginagamit sa GetAllSuppliersAsync service method)
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();

        // 3. Missing Method: AddSupplierAsync (ginagamit sa AddSupplierAsync service method)
        Task<Supplier> AddSupplierAsync(Supplier supplier);

        // ... (Iba pang methods kung mayroon man)
    }
}