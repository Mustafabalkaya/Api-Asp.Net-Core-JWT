using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Geçilemez")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]


        public string Password { get; set; }
    }
}
