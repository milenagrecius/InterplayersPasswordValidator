using InterplayersPassword.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterplayersApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        public PasswordController(IPasswordService password)
        {
            _passwordService = password;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePassword([FromBody] string password)
        {
            if (password == null)
            {
                return BadRequest();
            }

            var validatePassword = await _passwordService.ValidatePassword(password);
            return Ok(validatePassword);

        }
    }
}
