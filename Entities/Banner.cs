using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PromotionBannerManagement.Entities;

public class Banner
{
    [Key]
    public int id { get; set; }
    
    [Required]
    [StringLength(80)]
    public string title { get; set; }
    
    [Required]
    public string description { get; set; }
    
    [Required]
    public DateTime startDate { get; set; }
    
    [Required]
    public DateTime endDate { get; set; }
    
    public string status { get; set; } = "Active";
    
    public int CompanyId { get; set; }
    
    public Company company { get; set; }
}