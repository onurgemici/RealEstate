using RealEstateData;

namespace RealEstate.Models;

public class SearchViewModel
{
    public int? ProvinceId { get; set; }
    public int? DistrictId { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public Guid? CategoryId { get; set; }
    public PostTypes? PostType { get; set; }
}
