using AutoMapper;
using ShoeShop.Repository.Entities; // Kailangan para sa Entity Models
using ShoeShop.Services.DTOs;      // Kailangan para sa DTO Models

namespace ShoeShop.Services.Mapping
{
    // FINAL FIX 1: Kailangan itong mag-inherit sa AutoMapper.Profile
    // FINAL FIX 2: Kailangan itong maging public class
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- Shoe Mappings ---
            
            // Map CreateShoeDto to Shoe (para sa pag-create ng bagong sapatos)
            CreateMap<CreateShoeDto, Shoe>();

            // Map Shoe to ShoeDto (para sa pagbabalik ng data sa web app)
            CreateMap<Shoe, ShoeDto>();

            // --- Inventory/Transaction Mappings ---
            
            // Example: Map PullOutDto to StockPullOut Entity
            CreateMap<CreatePullOutDto, StockPullOut>();
            CreateMap<StockPullOut, PullOutRequestDto>();

            // Example: Map Supplier DTO to Entity
            CreateMap<SupplierDto, Supplier>();
            CreateMap<Supplier, SupplierDto>();

            CreateMap<StockPullOut, StockPullOutDto>().ReverseMap();

            // NOTE: Dagdagan lang ito ng iba pang DTO-Entity pairs na kailangan mo.
        }
    }
}