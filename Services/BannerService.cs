using PromotionBannerManagement.DTOs;
using PromotionBannerManagement.Entities;
using PromotionBannerManagement.Repositories;

namespace PromotionBannerManagement.Services;

public class BannerService: IBannerService
{
    private IBannerRepository _bannerRepository;

    public BannerService(IBannerRepository bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    
    public List<Banner> GetBanners()
    {
       var banners = _bannerRepository.GetAll();
       return banners;
    }

    public Banner? GetBanner(int id)
    {
        var banner = _bannerRepository.GetById(id);
        return banner;
    }

    public List<Banner> GetBannersByCompany(int companyId)
    {
        return _bannerRepository.GetBannersByCompany(companyId);
    }

    public List<Banner> GetBannersByPeriod(GetBannerByPeriodDTO period)
    {
        return _bannerRepository.GetBannersByPeriod(period.StartDate, period.EndDate);
    }
    
    public Banner CreateBanner(CreateBannerDTO banner)
    {
        if (banner.startDate < DateTime.Now)
        {
            throw new ArgumentException("Start date cannot be in the past.");
        }
        
        var newBanner = new Banner()
        {
            title = banner.title,
            description = banner.description,
            startDate = banner.startDate,
            endDate = banner.endDate,
            status = banner.startDate == DateTime.Now ? "Active" : "Inactive",
            CompanyId = banner.CompanyId,
        };
        
        var createdBanner = _bannerRepository.Add(newBanner);
        return createdBanner;
    }

    public Banner? UpdateBanner(int id, UpdateBannerDTO banner)
    {
        var existingBanner = _bannerRepository.GetById(id);

        if (existingBanner == null)
        {
            return null;
        }
        
        existingBanner.title = banner.title;
        existingBanner.description = banner.description;
        existingBanner.startDate = banner.startDate;
        existingBanner.endDate = banner.endDate;
        existingBanner.status = banner.isActive ? "Active" : "Inactive"; 
     
        var updatedBanner = _bannerRepository.Update(existingBanner);
        
        return updatedBanner;
    }

    public bool DeleteBanner(int id)
    {
        var existingBanner = _bannerRepository.GetById(id);

        if (existingBanner == null)
        {
            return false;
        }

        var deleteSuccess = _bannerRepository.Delete(existingBanner);

        return deleteSuccess;
    }
}