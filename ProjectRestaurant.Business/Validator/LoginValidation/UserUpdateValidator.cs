using FluentValidation;
using ProjectRestaurant.Entity.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Validator.LoginValidation
{
    public class UserUpdateValidator : AbstractValidator<UserDTOUpdateRequest>
    {
        public UserUpdateValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.LastName).NotEmpty().WithMessage("Kullanıcı Soyadı Boş Olamaz");
            RuleFor(q => q.Email).NotEmpty().WithMessage("Kullanıcı Emaili Boş Olamaz");
            RuleFor(q => q.PhoneNumber).NotEmpty().WithMessage("Kullanıcı Telefon Numarası Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Kullanıcı Şifresi Boş Olamaz");

            RuleFor(q => q.Guid).NotEmpty().WithMessage("Geçerli bir kullanıcı giriniz");
        }
    }
}
