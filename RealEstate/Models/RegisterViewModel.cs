using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models;

public class RegisterViewModel
{
    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [Remote(action: "VerifyEmail", controller: "Account", ErrorMessage = "{0} zaten kullanımdadır!")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir e-posta yazınız")]
    public string UserName { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Display(Name = "Parola")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Parola Tekrar")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [Compare("Password", ErrorMessage = "{0} alanı ile {1} alanı aynı olmalıdır!")]
    [DataType(DataType.Password)]
    public string PasswordCheck { get; set; }

    [Required]
    [Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
    public string PhoneNumber { get; set; } // Telefon numarası
}
