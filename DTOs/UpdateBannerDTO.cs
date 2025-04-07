namespace PromotionBannerManagement.DTOs;

public class UpdateBannerDTO
{
    public string title { get; set; }
    
    public string description { get; set; }
    
    public DateTime startDate { get; set; }
    
    public DateTime endDate { get; set; }
    
    public bool isActive { get; set; }
}