using AutoMapper;
<<<<<<< HEAD
=======
<<<<<<< HEAD
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs;

namespace ShoeShop.Services.Mapping
{
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs;
using System.Linq;

namespace ShoeShop.Services.Mapping
{
<<<<<<< HEAD
=======
=======
using ShoeShop.Repository.Entities; // Kailangan para sa Entity Models
using ShoeShop.Services.DTOs;      // Kailangan para sa DTO Models

namespace ShoeShop.Services.Mapping
{
    // FINAL FIX 1: Kailangan itong mag-inherit sa AutoMapper.Profile
    // FINAL FIX 2: Kailangan itong maging public class
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
            // --- Shoe Mappings ---
            CreateMap<Shoe, ShoeDto>().ReverseMap();
            CreateMap<CreateShoeDto, Shoe>();

            // --- Shoe Color Variation Mappings ---
            CreateMap<ShoeColorVariation, ShoeColorVariationDto>()
                .ForMember(dest => dest.IsLowStock,
                           opt => opt.MapFrom(src => src.StockQuantity <= src.ReorderLevel));
            CreateMap<CreateShoeColorVariationDto, ShoeColorVariation>();

            // --- Purchase Order Mappings ---
            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<CreatePurchaseOrderDto, PurchaseOrder>();
            CreateMap<PurchaseOrderItem, PurchaseOrderItemDto>();
            CreateMap<CreatePurchaseOrderItemDto, PurchaseOrderItem>();

            // --- Pull Out Mappings ---
            // Tandaan: Kailangan ng Include() sa Repository para gumana ang ShoeName mapping
            CreateMap<StockPullOut, PullOutRequestDto>()
                .ForMember(dest => dest.ShoeName,
                           opt => opt.MapFrom(src => src.ShoeColorVariation.Shoe.Name));

            CreateMap<CreatePullOutDto, StockPullOut>();

            // --- Supplier Mappings ---
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }
}
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
            // --- SHOE MAPPINGS (DTO <-> ENTITY) ---

            // Shoe Entity to Shoe DTO (Kaya mong i-display ang database data)
            CreateMap<Shoe, ShoeDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RetailPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ReverseMap() // Pinapagana ang mapping mula DTO pabalik sa Entity
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RetailPrice)) // Tugma sa DTO->Entity
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))   // Tugma sa DTO->Entity
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            // CreateShoeDto to Shoe Entity (Ginagamit sa CreateShoeAsync)
            CreateMap<CreateShoeDto, Shoe>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RetailPrice))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Hayaan ang database ang magbigay ng Id


            // --- COLOR VARIATIONS MAPPINGS ---

            // DTO <-> Entity
            CreateMap<ColorVariationDto, ShoeColorVariation>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color))
                .ReverseMap()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.ColorName));


            // CreateColorVariationDto to ShoeColorVariation Entity
            CreateMap<CreateColorVariationDto, ShoeColorVariation>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // --- INVENTORY / TRANSACTION MAPPINGS ---

            // Pull Out Requests
            CreateMap<CreatePullOutDto, StockPullOut>();
            CreateMap<StockPullOut, PullOutRequestDto>().ReverseMap();

            // Additional PullOut Mapping for completeness
            CreateMap<StockPullOut, StockPullOutDto>().ReverseMap();


            // --- SUPPLIER MAPPINGS ---

            // Assuming SupplierDto and Supplier exist
            CreateMap<SupplierDto, Supplier>().ReverseMap(); // Two-way mapping
        }
    }
}
<<<<<<< HEAD
=======
=======
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
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
