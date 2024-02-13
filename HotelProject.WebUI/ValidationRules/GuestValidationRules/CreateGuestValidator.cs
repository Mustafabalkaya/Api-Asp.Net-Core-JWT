using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen En az 3 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Lütfen En az 2 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Lütfen En az 3 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen En fazla 20 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.SurName).MaximumLength(30).WithMessage("Lütfen En fazla 30 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Lütfen En fazla 20 Karakter Veri Girişi Yapınız");

        }
    }
}
