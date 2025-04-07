using Microsoft.AspNetCore.Mvc;
using PromotionBannerManagement.DTOs;
using PromotionBannerManagement.Entities;
using PromotionBannerManagement.Services;

namespace PromotionBannerManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("companies")]
        public IActionResult GetCompanies()
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("companies/{id}")]
        public IActionResult GetParticularCompany(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound("Company not found.");
            }
            return Ok(company);
        }

        [HttpPost("companies")]
        public IActionResult AddCompany([FromBody] CreateCompanyDTO company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _companyService.CreateCompany(company);
            if (result)
            {
                return Created("",company);
            }

            return BadRequest("Failed to create the company.");
        }

        [HttpPut("companies/{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] UpdateCompanyDTO company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _companyService.UpdateCompany(id, company);
            if (!result)
            {
                return NotFound("Company not found.");
            }

            return Ok(company);
        }

        [HttpDelete("companies/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var result = _companyService.DeleteCompany(id);
            if (!result)
            {
                return NotFound("Company not found.");
            }

            return Ok("Company deleted.");
        }
    }
}
