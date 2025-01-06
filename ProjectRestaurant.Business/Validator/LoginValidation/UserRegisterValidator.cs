using FluentValidation;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Validator.LoginValidation
{
    public class UserRegisterValidator:AbstractValidator<UserDTORequest>
    {
        private static IUserService _userService;
        public static void Initialize(IUserService userService)
        {
            _userService = userService;
        }
        public UserRegisterValidator()
        {

            RuleFor(q => q.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.Email).NotEmpty().WithMessage("Email Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.Email).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.Email).MustAsync(CheckUniqueEMail).WithMessage("Farklı Bir E-Posta Adresi Giriniz.");
            RuleFor(q => q.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Olamaz");
        }

        private async Task<bool> CheckUniqueEMail(string eMail, CancellationToken arg2)
        {
            var existingUser = await _userService.GetUserByEMailAsync(eMail);
            return existingUser is null;
        }
    }
}
