using RealEstateData;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models;

public enum PostTypesView
{
    [Display(Name = "Satılık")] ForSale, [Display(Name = "Kiralık")] ForRent
}
public class PostViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    [Display(Name = "İl/İlçe")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public int DistrictId { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public Guid CategoryId { get; set; }

    [Display(Name = "İlan Başlığı")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public string Name { get; set; }

    public string Image { get; set; }

    [Display(Name = "Açıklama")]
    public string Descriptions { get; set; }

    [Display(Name = "Fiyat")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public decimal Price { get; set; }


    [Display(Name = "Görsel")]
    public IFormFile? ImageFile { get; set; }
    [Display(Name = "Foto Galeri")]
    public IEnumerable<IFormFile>? ImageFiles { get; set; }
    public DateTime Date { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [Display(Name = "İlan Türü")]
    public PostTypesView Type { get; set; }

    public IEnumerable<Guid> Specs { get; set; } // Özellikler ID'leri

    // Yeni alanlar: Kategorinin, İl/İlçenin ve Özelliklerin adları
    public string CategoryName { get; set; }

    public string ProvinceName { get; set; }

    public string DistrictName { get; set; }
    public IEnumerable<string> SpecificationNames { get; set; }

    // Add Username and PhoneNumber properties
    public string UserName { get; set; }  // Kullanıcı adı
    public string PhoneNumber { get; set; }  // Telefon numarası
}