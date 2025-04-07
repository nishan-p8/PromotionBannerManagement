using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement.Repositories;

public class BannerRepository: IBannerRepository
{
    private ApplicationDbContext _dbContext;
    public BannerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Banner> GetAll()
    {
       return _dbContext.Banners.ToList();
    }

    public Banner? GetById(int id)
    {
        return _dbContext.Banners.FirstOrDefault(b => b.id == id);
    }

    public List<Banner> GetBannersByCompany(int companyId)
    {
        return _dbContext.Banners.Where(b => b.CompanyId == companyId).ToList();
    }

    public List<Banner> GetBannersByPeriod(DateTime startDate, DateTime endDate)
    {
        return _dbContext.Banners
            .Where(b => b.startDate <= endDate && b.endDate >= startDate)
            .ToList();    }
    
    public Banner Add(Banner banner)
    {
        var newBanner  = _dbContext.Banners.Add(banner);
        _dbContext.SaveChanges();
        return newBanner.Entity;
    }

    public Banner Update(Banner banner)
    {
        var updatedBanner  = _dbContext.Banners.Update(banner);
        _dbContext.SaveChanges();
        return updatedBanner.Entity;
    }

    public bool Delete(Banner banner)
    {
        _dbContext.Banners.Remove(banner);
        _dbContext.SaveChanges();
        return true;
    }
}