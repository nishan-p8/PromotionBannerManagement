using PromotionBannerManagement.DTOs;
using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement.Services;

public interface ICompanyService
{
    List<Company> GetAllCompanies();
    
    Company GetCompanyById(int id);
    
    bool CreateCompany(CreateCompanyDTO company);
    
    bool UpdateCompany(int id, UpdateCompanyDTO company);
    
    bool DeleteCompany(int id);
}