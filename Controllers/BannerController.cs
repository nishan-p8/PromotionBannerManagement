using Microsoft.AspNetCore.Mvc;
using PromotionBannerManagement.DTOs;
using PromotionBannerManagement.Entities;
using PromotionBannerManagement.Services;

namespace PromotionBannerManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class BannerController: ControllerBase
{
    private IBannerService _bannerService;

    public BannerController(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

   [HttpGet("promotional-banners")]
        public IActionResult GetAllBanners()
        {
            var banners = _bannerService.GetBanners();
            return Ok(banners);
        }

        [HttpGet("promotional-banners/{id}")]
        public IActionResult GetBannerById(int id)
        {
            var banner = _bannerService.GetBanner(id);
            if (banner == null)
            {
                return NotFound("Banner not found.");
            }
            return Ok(banner);
        }

        [HttpGet("promotional-banners/company/{companyId}")]
        public IActionResult GetBannersByCompany(int companyId)
        {
            var banners = _bannerService.GetBannersByCompany(companyId);
            if (banners == null || !banners.Any())
            {
                return NotFound("No banners found for the specified company.");
            }
            return Ok(banners);
        }
        
        [HttpPost("promotional-banners/period")]
        public IActionResult GetBannersByCertainPeriod(GetBannerByPeriodDTO period)
        {
            var banners = _bannerService.GetBannersByPeriod(period);
            if (banners == null || !banners.Any())
            {
                return NotFound("No banners found for the specified period.");
            }
            return Ok(banners);
        }

        [HttpPost("promotional-banners")]
        public IActionResult CreateBanner([FromBody] CreateBannerDTO banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBanner = _bannerService.CreateBanner(banner);
            return Created("", createdBanner);
        }

        [HttpPut("promotional-banners/{id}")]
        public IActionResult UpdateBanner(int id, [FromBody] UpdateBannerDTO banner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBanner = _bannerService.UpdateBanner(id, banner);
            if (updatedBanner == null)
            {
                return NotFound("Banner not found.");
            }
            return Ok(updatedBanner);
        }

        [HttpDelete("promotional-banners/{id}")]
        public IActionResult DeleteBanner(int id)
        {
            var result = _bannerService.DeleteBanner(id);
            if (!result)
            {
                return NotFound("Banner not found.");
            }
            return Ok("Banner deleted.");
        }
    
}