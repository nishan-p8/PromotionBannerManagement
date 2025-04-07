namespace PromotionBannerManagement.DTOs;

public class CreateBannerDTO
{
    public string title { get; set; }
    
    public string description { get; set; }
    
    public DateTime startDate { get; set; }
    
    public DateTime endDate { get; set; }
    
    public int CompanyId { get; set; }
}