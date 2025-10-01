using AutoMapper;
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs;

namespace ShoeShop.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
