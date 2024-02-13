using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Lütfen Oda Numarasını  giriniz")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Görseli  giriniz")]

        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen Fiyat Bilgisi  giriniz")]

        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığı Bilgisi  giriniz")]
        [StringLength(100,ErrorMessage ="Lütfen En Fazla 100 karakter veri girişi yapınız")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yatak Sayısı  giriniz")]

        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Banyo Sayısı  giriniz")]

        public string BathCount { get; set; }
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Lütfen Açıklama  giriniz")]

        public string Description { get; set; }
    }
}
