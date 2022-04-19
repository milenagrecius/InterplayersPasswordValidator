using InterplayersPassword.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Service;

namespace InterplayersPassword.Core
{
    public class PasswordService : IPasswordService
    {
        public Task<List<string>> ValidatePassword(string password)
        {
            var validation = new PasswordValidator();
            var passwordViewModel = new PasswordEntities(password);
            var resultList = new List<string>();
            var result = validation.Validate(passwordViewModel).Errors;

            foreach (var item in result)
                resultList.Add(item.ErrorMessage);

            if (resultList.Count > 0)
                return Task.FromResult(resultList);

            resultList.Add("A senha foi validada com sucesso!!");
            return Task.FromResult(resultList);

        }
    }
}


