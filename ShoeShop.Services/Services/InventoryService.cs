using AutoMapper;
using ShoeShop.Repository.Entities;
<<<<<<< HEAD
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
=======
<<<<<<< HEAD
// ITO ANG FINAL FIX: Gamitin ang alias para wala nang ambiguity
using RepoInterfaces = ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces; // Para sa IInventoryService
=======
<<<<<<< HEAD
using ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Services.Services
{
    public class InventoryService : IInventoryService
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        // Ginamit ang alias
        private readonly RepoInterfaces.IShoeRepository _shoeRepository;
        private readonly IMapper _mapper;

=======
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        private readonly IShoeRepository _shoeRepository;
        private readonly IStockPullOutRepository _pullOutRepository;
        private readonly IMapper _mapper;

        public InventoryService(IShoeRepository shoeRepository,
                                IStockPullOutRepository pullOutRepository,
                                IMapper mapper)
        {
            _shoeRepository = shoeRepository;
            _pullOutRepository = pullOutRepository;
            _mapper = mapper;
        }

        // --- Shoes ---

        public async Task<ShoeDto> CreateShoeAsync(CreateShoeDto dto)
        {
            var newShoeEntity = _mapper.Map<Shoe>(dto);
            newShoeEntity.CreatedDate = DateTime.UtcNow;
            newShoeEntity.IsActive = true;

            await _shoeRepository.AddAsync(newShoeEntity);
            await _shoeRepository.SaveChangesAsync();

            return _mapper.Map<ShoeDto>(newShoeEntity);
<<<<<<< HEAD
=======
=======
// FINAL FIX: Idinagdag ang alias na ito para maging valid ang 'RepoInterfaces' type
using RepoInterfaces = ShoeShop.Repository.Interfaces;
using ShoeShop.Services.DTOs;
using ShoeShop.Services.Interfaces;
using System;
using System.Collections.Generic; // Kailangan para sa IEnumerable, List
using System.Linq; // Kailangan para sa FirstOrDefault, Any
using System.Threading.Tasks; // Kailangan para sa Task

namespace ShoeShop.Services.Services
{
    // FINAL FIX: Public ang class
    public class InventoryService : IInventoryService
    {
        // Ginamit ang alias: Walang ambiguity sa type
        private readonly RepoInterfaces.IShoeRepository _shoeRepository;
        private readonly IMapper _mapper;

        // Ginamit ang alias sa constructor
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        public InventoryService(RepoInterfaces.IShoeRepository shoeRepository, IMapper mapper)
        {
            _shoeRepository = shoeRepository;
            _mapper = mapper;
        }

        public async Task<ShoeDto> CreateShoeAsync(CreateShoeDto shoeDto)
        {
            var shoe = _mapper.Map<Shoe>(shoeDto);
            shoe.IsActive = true;
            shoe.CreatedDate = DateTime.UtcNow;

            foreach (var variation in shoe.ColorVariations)
            {
                variation.IsActive = true;
            }

            var createdShoe = await _shoeRepository.AddShoeAsync(shoe);
            return _mapper.Map<ShoeDto>(createdShoe);
<<<<<<< HEAD
=======
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        }

        public async Task<IEnumerable<ShoeDto>> GetAllShoesAsync()
        {
<<<<<<< HEAD
            var shoes = await _shoeRepository.GetAllWithVariationsAsync();
=======
<<<<<<< HEAD
            var shoes = await _shoeRepository.GetAllShoesAsync();
=======
<<<<<<< HEAD
            var shoes = await _shoeRepository.GetAllWithVariationsAsync();
=======
            var shoes = await _shoeRepository.GetAllShoesAsync();
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
            return _mapper.Map<IEnumerable<ShoeDto>>(shoes);
        }

        public async Task<ShoeDto?> GetShoeByIdAsync(int id)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(id);
            return shoe == null ? null : _mapper.Map<ShoeDto>(shoe);
        }

        // FIX: Idinagdag ang missing method para ma-implement ang IInventoryService
        public async Task<int> GetStockQuantityAsync(int shoeId)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);

            if (shoe == null)
            {
                return 0;
            }

            return shoe.ColorVariations.Sum(c => c.StockQuantity);
        }

        public async Task UpdateShoeAsync(int id, CreateShoeDto dto)
        {
            var shoeToUpdate = await _shoeRepository.GetByIdWithVariationsAsync(id);
            if (shoeToUpdate == null)
<<<<<<< HEAD
=======
=======
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
            var shoe = await _shoeRepository.GetShoeByIdAsync(id);
            return _mapper.Map<ShoeDto>(shoe);
        }

        public async Task UpdateShoeAsync(int id, CreateShoeDto updatedShoeDto)
        {
            var existingShoe = await _shoeRepository.GetShoeByIdAsync(id);
            if (existingShoe == null)
<<<<<<< HEAD
=======
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
            {
                throw new KeyNotFoundException($"Shoe with ID {id} not found.");
            }

<<<<<<< HEAD
=======
<<<<<<< HEAD
            _mapper.Map(updatedShoeDto, existingShoe);
            await _shoeRepository.UpdateShoeAsync(existingShoe);
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
            _mapper.Map(dto, shoeToUpdate);

            // Tiyakin na ang ColorVariations ay maayos na na-u-update
            var updatedVariations = dto.ColorVariations.Select(v => _mapper.Map<ShoeColorVariation>(v)).ToList();
            shoeToUpdate.ColorVariations.Clear();
            foreach (var variation in updatedVariations)
            {
                shoeToUpdate.ColorVariations.Add(variation);
            }

            await _shoeRepository.UpdateAsync(shoeToUpdate);
            await _shoeRepository.SaveChangesAsync();
<<<<<<< HEAD
=======
=======
            _mapper.Map(updatedShoeDto, existingShoe);
            await _shoeRepository.UpdateShoeAsync(existingShoe);
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        }

        public async Task DeleteShoeAsync(int id)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
            var shoeToDelete = await _shoeRepository.GetByIdWithVariationsAsync(id);
            if (shoeToDelete != null)
            {
                // FIX: Ang interface ay nangangailangan ng Shoe entity, hindi ID.
                await _shoeRepository.DeleteAsync(shoeToDelete);
                await _shoeRepository.SaveChangesAsync();
            }
        }

        public async Task<bool> AdjustStockAsync(int shoeId, int quantityChange, string reason, string user)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);
            if (shoe == null) return false;

            var variation = shoe.ColorVariations.FirstOrDefault();
            if (variation == null) return false;

            variation.StockQuantity += quantityChange;

            // Ito ang nagre-record ng Pull-Out/Stock-In Transaction
            var pullOut = new StockPullOut
            {
                ShoeColorVariationId = variation.Id,
                Quantity = Math.Abs(quantityChange), // Ginagamit ang absolute value
                Reason = reason,
                RequestedBy = user,
                PullOutDate = DateTime.UtcNow,
                Status = quantityChange > 0 ? "RECEIVED" : "PULLED_OUT" // Status based on quantityChange sign
            };

            await _pullOutRepository.AddAsync(pullOut);
            await _shoeRepository.UpdateAsync(shoe);
            await _shoeRepository.SaveChangesAsync();
<<<<<<< HEAD
=======
=======
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
            await _shoeRepository.DeleteShoeAsync(id);
        }

        public async Task<bool> AdjustStockAsync(int colorVariationId, int quantityChange, string reason, string user)
        {
<<<<<<< HEAD
=======
            // Paggamit ng _shoeRepository
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
            var shoe = await _shoeRepository.GetShoeByColorVariationIdAsync(colorVariationId);

            if (shoe == null)
            {
                throw new KeyNotFoundException($"Shoe variation ID {colorVariationId} not found.");
            }

            var variation = shoe.ColorVariations.FirstOrDefault(v => v.Id == colorVariationId);

            if (variation == null)
            {
                throw new KeyNotFoundException($"Color variation ID {colorVariationId} not found on shoe.");
            }

            if (variation.StockQuantity + quantityChange < 0)
            {
                throw new InvalidOperationException("Stock adjustment results in negative stock.");
            }

            variation.StockQuantity += quantityChange;
            await _shoeRepository.UpdateShoeAsync(shoe);
<<<<<<< HEAD
=======
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7

            return true;
        }

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        // --- Color Variations ---

        public async Task<ColorVariationDto> AddColorVariationAsync(int shoeId, CreateColorVariationDto dto)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);
            if (shoe == null) throw new KeyNotFoundException("Shoe not found");

            var newVariation = _mapper.Map<ShoeColorVariation>(dto);
            newVariation.ShoeId = shoeId;

            shoe.ColorVariations.Add(newVariation);
            await _shoeRepository.UpdateAsync(shoe);
            await _shoeRepository.SaveChangesAsync();

            return _mapper.Map<ColorVariationDto>(newVariation);
        }

        public async Task<IEnumerable<ColorVariationDto>> GetColorVariationsByShoeIdAsync(int shoeId)
        {
            var shoe = await _shoeRepository.GetByIdWithVariationsAsync(shoeId);
            return shoe == null ? Enumerable.Empty<ColorVariationDto>()
                                  : _mapper.Map<IEnumerable<ColorVariationDto>>(shoe.ColorVariations);
        }

        public async Task<ColorVariationDto?> GetColorVariationByIdAsync(int variationId)
        {
            var allShoes = await _shoeRepository.GetAllWithVariationsAsync();
            var variation = allShoes.SelectMany(s => s.ColorVariations)
                                     .FirstOrDefault(v => v.Id == variationId);

            return variation == null ? null : _mapper.Map<ColorVariationDto>(variation);
        }

        public async Task<ColorVariationDto> UpdateColorVariationAsync(int variationId, CreateColorVariationDto dto)
        {
            var allShoes = await _shoeRepository.GetAllWithVariationsAsync();
            var shoe = allShoes.FirstOrDefault(s => s.ColorVariations.Any(v => v.Id == variationId));

            if (shoe == null) throw new KeyNotFoundException("Variation not found");

            var variationToUpdate = shoe.ColorVariations.First(v => v.Id == variationId);

            _mapper.Map(dto, variationToUpdate);

            await _shoeRepository.UpdateAsync(shoe);
            await _shoeRepository.SaveChangesAsync();

            return _mapper.Map<ColorVariationDto>(variationToUpdate);
        }

        public async Task DeleteColorVariationAsync(int variationId)
        {
            var allShoes = await _shoeRepository.GetAllWithVariationsAsync();
            var shoe = allShoes.FirstOrDefault(s => s.ColorVariations.Any(v => v.Id == variationId));

            if (shoe != null)
            {
                var variationToDelete = shoe.ColorVariations.First(v => v.Id == variationId);
                shoe.ColorVariations.Remove(variationToDelete);

                await _shoeRepository.UpdateAsync(shoe);
                await _shoeRepository.SaveChangesAsync();
            }
        }

        // --- Pull Out History ---

        // Pinalitan ang lumang GetPullOutHistoryForShoeAsync(int shoeId)
        public async Task<IEnumerable<StockPullOutDto>> GetAllPullOutHistoryAsync()
        {
            // Kukunin ang lahat ng StockPullOut Entities (Ipagpalagay na ang GetAllPullOutsAsync() ay available)
            var allPullOuts = await _pullOutRepository.GetAllPullOutsAsync();

            // I-ma-map ang Entities sa DTOs
            return _mapper.Map<IEnumerable<StockPullOutDto>>(allPullOuts);
        }

        public class InventoryMappingProfile : Profile
        {
            public InventoryMappingProfile()
            {
                // I-map ang database entity (source) sa DTO (destination)
                CreateMap<StockPullOut, PullOutRequestDto>();
            }
<<<<<<< HEAD
=======
=======
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        public async Task<int> GetStockQuantityAsync(int colorVariationId)
        {
            var shoe = await _shoeRepository.GetShoeByColorVariationIdAsync(colorVariationId);
            if (shoe == null)
            {
                throw new KeyNotFoundException($"Shoe variation ID {colorVariationId} not found.");
            }
            return shoe.ColorVariations.FirstOrDefault(v => v.Id == colorVariationId)?.StockQuantity ?? 0;
<<<<<<< HEAD
=======
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        }
    }
}