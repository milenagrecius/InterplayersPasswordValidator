using InterplayersPassword.Core.Entities;
using Service;
using Xunit;

namespace InterplayersPassword.Tests
{
    public class PasswordTest
    {
        [Theory]
        [InlineData("123456789Aa$")]
        public void Password_IsValid(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("123456789Aa$")]
        public void Password_IsNotNull(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid, "A senha não deve ser vazia");
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123456789Aa$")]
        public void Password_Min9Characters(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);

            Assert.True(result.IsValid, "A senha deve conter, no mínimo, 9 caracteres.");

        }

        [Theory]
        [InlineData("@Abcdefgh")]
        [InlineData("@Abcdefgh1")]
        public void Password_Min1Digit(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid, "A senha deve conter ao menos 1 dígito.");
        }

        [Theory]
        [InlineData("@ABCDEFGH1")]
        [InlineData("@Abcdefgh1")]
        public void Password_LowerCase(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid, "A senha deve conter ao menos uma letra minúscula.");
        }

        [Theory]
        [InlineData("@abcdefgh1")]
        [InlineData("@Abcdefgh1")]
        public void Password_UpperCase(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid, "A senha deve conter ao menos uma letra maiúscula.");
        }

        [Theory]
        [InlineData("Abcdefgh1")]
        [InlineData("@Abcdefgh1")]
        public void Password_Alphanumeric(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid, "senha deve conter pelo menos um caractere especial (!@#$%^&*()-+).");
        }

        [Theory]
        [InlineData("@Abcdefgh1")]
        [InlineData("@AAbcdefgh1")]
        public void Password_DuplicateCharacter(string password)
        {
            var passwordEntities = new PasswordEntities(password);
            var result = new PasswordValidator().Validate(passwordEntities);
            Assert.True(result.IsValid, "A senha NÃO deve possuir caracteres repetidos.");
        }
    }
}
