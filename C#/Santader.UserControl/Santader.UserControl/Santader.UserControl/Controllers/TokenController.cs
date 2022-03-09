using Microsoft.AspNetCore.Mvc;
using Santader.UserControl.Models;
using Santader.UserControl.Repositories;
using Santader.UserControl.Services;
using Serilog;

namespace Santader.UserControl.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IUserRepository repos;
        public TokenController(IUserRepository _repos)
        {
            repos = _repos;
        }

        [HttpPost]
        public async Task<IActionResult> Get(Login login)
        {
            try
            {
                Log.Information("Iniciando Post Token");

                User _users = await repos.FindUserAsync(login.UserName, login.Password);
                if (_users == null)
                {
                    Log.ForContext("Action", $"Token").Information($"API Token GET Invalid User Name or password.");
                    return Forbid();
                }
                JsonWebToken tokeService = TokenServices.GenarateToken(_users);
                Log.ForContext("Action", $"Token").Information($"API chamada por {tokeService}.");

                return Ok(tokeService);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                Log.ForContext("Action", $"Token").Information($"API Retorno 200");
            }
        }
    }
}

