using AutoMapper;
using ShoeShop.Repository.Entities;
using ShoeShop.Services.DTOs;
using System.Linq;

namespace ShoeShop.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- SHOE MAPPINGS (DTO <-> ENTITY) ---

            CreateMap<Shoe, ShoeDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RetailPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ReverseMap()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RetailPrice))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CreateShoeDto, Shoe>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RetailPrice))
                .ForMember(dest => dest.ColorVariations, opt => opt.MapFrom(src => src.ColorVariations))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // --- COLOR VARIATIONS MAPPINGS ---

            CreateMap<ColorVariationDto, ShoeColorVariation>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color))
                .ReverseMap()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.ColorName));

            CreateMap<CreateColorVariationDto, ShoeColorVariation>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // --- INVENTORY / TRANSACTION MAPPINGS ---

            CreateMap<CreatePullOutDto, StockPullOut>();
            CreateMap<StockPullOut, PullOutRequestDto>().ReverseMap();
            CreateMap<StockPullOut, StockPullOutDto>().ReverseMap();

            // --- SUPPLIER MAPPINGS ---

            CreateMap<SupplierDto, Supplier>().ReverseMap();

            // --- PURCHASE ORDER MAPPINGS (THESE ARE THE NEW MAPPINGS) ---

            // Maps the DTO used for creating a purchase order to the database entity.
            CreateMap<CreatePurchaseOrderDto, PurchaseOrder>();

            // Maps a single item from the create DTO to the database entity.
            // It correctly maps the 'ShoeId' from the DTO to 'ShoeColorVariationId' in the entity.
            CreateMap<PurchaseOrderItemDto, PurchaseOrderItem>()
                .ForMember(dest => dest.ShoeColorVariationId, opt => opt.MapFrom(src => src.ShoeId))
                .ForMember(dest => dest.QuantityOrdered, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => src.UnitPrice));

            // Maps a PurchaseOrder entity from the database to the DTO used for displaying it.
            CreateMap<PurchaseOrder, PurchaseOrderDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : string.Empty));
        }
    }
}