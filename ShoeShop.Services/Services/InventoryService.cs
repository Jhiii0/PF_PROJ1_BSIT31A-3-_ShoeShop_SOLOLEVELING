using AutoMapper;
using ShoeShop.Repository.Entities;
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
        }

        public async Task<IEnumerable<ShoeDto>> GetAllShoesAsync()
        {
            var shoes = await _shoeRepository.GetAllShoesAsync();
            return _mapper.Map<IEnumerable<ShoeDto>>(shoes);
        }

        public async Task<ShoeDto?> GetShoeByIdAsync(int id)
        {
            var shoe = await _shoeRepository.GetShoeByIdAsync(id);
            return _mapper.Map<ShoeDto>(shoe);
        }

        public async Task UpdateShoeAsync(int id, CreateShoeDto updatedShoeDto)
        {
            var existingShoe = await _shoeRepository.GetShoeByIdAsync(id);
            if (existingShoe == null)
            {
                throw new KeyNotFoundException($"Shoe with ID {id} not found.");
            }

            _mapper.Map(updatedShoeDto, existingShoe);
            await _shoeRepository.UpdateShoeAsync(existingShoe);
        }

        public async Task DeleteShoeAsync(int id)
        {
            await _shoeRepository.DeleteShoeAsync(id);
        }

        public async Task<bool> AdjustStockAsync(int colorVariationId, int quantityChange, string reason, string user)
        {
            // Paggamit ng _shoeRepository
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

            return true;
        }

        public async Task<int> GetStockQuantityAsync(int colorVariationId)
        {
            var shoe = await _shoeRepository.GetShoeByColorVariationIdAsync(colorVariationId);
            if (shoe == null)
            {
                throw new KeyNotFoundException($"Shoe variation ID {colorVariationId} not found.");
            }
            return shoe.ColorVariations.FirstOrDefault(v => v.Id == colorVariationId)?.StockQuantity ?? 0;
        }
    }
}