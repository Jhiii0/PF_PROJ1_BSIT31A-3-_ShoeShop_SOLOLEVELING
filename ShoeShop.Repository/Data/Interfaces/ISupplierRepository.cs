using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// CHANGE THIS NAMESPACE
namespace ShoeShop.Repository.Data.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier?> GetSupplierByIdAsync(int supplierId);
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllAsync(); // Ensure this method exists
    }
}