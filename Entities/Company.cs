using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PromotionBannerManagement.Entities;


[Index(nameof(PhoneNumber), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class Company
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public ICollection<Banner> Banners { get; set; }
}