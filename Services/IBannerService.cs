using PromotionBannerManagement.DTOs;
using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement.Services;

public interface IBannerService
{
    List<Banner> GetBanners();
    
    Banner? GetBanner(int id);

    List<Banner> GetBannersByCompany(int companyId);
    
    List<Banner> GetBannersByPeriod(GetBannerByPeriodDTO period);

    Banner? CreateBanner(CreateBannerDTO banner);
    
    Banner? UpdateBanner(int id, UpdateBannerDTO banner);
    
    bool DeleteBanner(int id);
}