﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService offerDiscountService;

        public OfferDiscountController(IOfferDiscountService OfferDiscountService)
        {
            this.offerDiscountService = OfferDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await offerDiscountService.GetAllOfferDiscountsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var values = await offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Özel Teklif başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await offerDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("Özel Teklif başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Özel Teklif başarıyla güncellendi");
        }
    }
}
