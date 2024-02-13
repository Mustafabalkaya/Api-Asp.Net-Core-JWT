using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Hizmet İkon Linki Giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100,ErrorMessage ="Hizmet Başlığı En fazla 100 Karakter Olmalıdır")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet Konusu Giriniz")]

        public string Description { get; set; }
    }
}
