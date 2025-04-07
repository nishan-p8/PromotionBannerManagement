using Microsoft.EntityFrameworkCore;
using PromotionBannerManagement.Entities;

namespace PromotionBannerManagement;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Company> Companies { get; set; }
}