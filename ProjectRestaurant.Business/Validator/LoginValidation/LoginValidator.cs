using FluentValidation;
using ProjectRestaurant.Entity.DTO.LoginDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Validator.LoginValidation
{
    public class LoginValidator:AbstractValidator<LoginDTORequest>
    {
        public LoginValidator()
        {
            RuleFor(q => q.Email).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}
