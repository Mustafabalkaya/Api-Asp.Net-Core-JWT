using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad Alanı Boş Geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Alanı Boş Geçilemez")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şehir Alanı Boş Geçilemez")]

        public string City { get; set; }
        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]

        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Geçilemez")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor ")]
        public string ConfirmPassword { get; set; }
       
      //  public int WorkLocationID { get; set; }


    }
}
