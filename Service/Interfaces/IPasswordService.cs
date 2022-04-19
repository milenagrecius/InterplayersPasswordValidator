using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterplayersPassword.Core
{

    public interface IPasswordService
    {
        Task<List<string>> ValidatePassword(string input);
    }

}
