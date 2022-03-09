using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Santader.UserControl.Models;
using Santader.UserControl.Repositories;
using Serilog;

namespace Santader.UserControl.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _appDbContext;
        private readonly IDeleteRepository _appDbContextOra;

        public UsersController(IUserRepository Context, IDeleteRepository ContextOra)
        {
            _appDbContext = Context;
            _appDbContextOra = ContextOra;
        }

        [HttpGet("V1/ListUser")]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                Log.Information("ResignationUser");
                return Ok(await _appDbContext.GetAllUserAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("V1/InsertUser")]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<List<User>>> Post(List<User> users)
        {
            try
            {
                Log.Information("InsertUser");
                var i = _appDbContext.Create(users);
                return Ok(i);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("V1/ResignationUser {IdUser}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> ResignationUser(int IdUser)
        {
            try
            {
                Log.Information("ResignationUser");
                bool resp = await _appDbContextOra.InsertDeleteUser(IdUser);
                return Ok("ok");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);    
                return BadRequest(ex.Message);  
            }

        }

        [HttpPost("V1/RemoveUser")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> DisebledUser()
        {
            try
            {
                var resp = _appDbContext.DisebledUser();
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }



    }
}
