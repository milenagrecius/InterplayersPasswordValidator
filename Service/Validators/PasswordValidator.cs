using FluentValidation;
using InterplayersPassword.Core.Entities;
using System.Linq;
using System.Text.RegularExpressions;

namespace Service
{
    public class PasswordValidator : AbstractValidator<PasswordEntities>
    {

        private bool ValidateDigit(string password)
        {
            if (password.Any(x => char.IsDigit(x)))
                return true;
            
            return false;
        }

        private bool ValidateLowerCase(string password)
        {
            if (password.Any(x => char.IsLower(x)))
                return true;
            
            return false;
        }

        private bool ValidateUpperCase(string password)
        {
            if (password.Any(x => char.IsUpper(x)))
                return true;
            
            return false;
        }

        private bool ValidateAlphanumeric(string password)
        {

            if (Regex.IsMatch(password, "(?=.*[!@#$%^&*()-+])"))
                return true;

            return false;
        }

        private bool ValidateDuplicateCharacter(string password)
        {
            bool duplicatecharacter = false;

            if (password != string.Empty)
            {
                for (int currentletterindex = 0; currentletterindex < password.Length; currentletterindex++)
                {
                    if (currentletterindex < password.Length - 1)
                    {
                        var currentletter = password.Substring(currentletterindex, 1);

                        if (password.IndexOf(currentletter, currentletterindex + 1) > -1)
                        {
                            duplicatecharacter = true;
                            break;
                        }
                    }
                }
            }

            return !duplicatecharacter;
        }

        public PasswordValidator()
        {
            RuleFor(x => x.Password).NotNull().WithMessage("Senha inválida - Sua senha não pode estar vazia!")
                .Length(9, 20).WithMessage("Sua senha deve conter, no mínimo, 9 caracteres.")
                .Must(ValidateDigit).WithMessage("Sua senha deve conter ao menos 1 dígito.")
                .Must(ValidateLowerCase).WithMessage("Sua senha deve conter ao menos uma letra minúscula.")
                .Must(ValidateUpperCase).WithMessage("Sua senha deve conter ao menos uma letra maiúscula.")
                .Must(ValidateAlphanumeric).WithMessage("Sua senha deve conter pelo menos um caractere especial (!@#$%^&*()-+).")
                .Must(ValidateDuplicateCharacter).WithMessage("Sua senha NÃO deve possuir caracteres repetidos.");
        }
    }
}
