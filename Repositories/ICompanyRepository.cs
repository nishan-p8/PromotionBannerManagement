using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement.Repositories;

public interface ICompanyRepository
{
    List<Company> GetAll();
    
    Company? GetById(int id);
    
    Company Create(Company company);
    
    Company Update(Company company);
    
    bool Delete(Company company);
}