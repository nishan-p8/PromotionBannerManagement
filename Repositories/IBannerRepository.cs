using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement.Repositories;

public interface IBannerRepository
{
    List<Banner> GetAll();
    
    Banner? GetById(int id);
    
    List<Banner> GetBannersByCompany(int companyId);
    
    List<Banner> GetBannersByPeriod(DateTime startDate, DateTime endDate);
    
    Banner Add(Banner banner);
    
    Banner Update(Banner banner);
    
    bool Delete(Banner banner);
}