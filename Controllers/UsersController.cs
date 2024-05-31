using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using IzometriService.Api.Controllers.Base;
using IzometriService.Business.Abstract.API;
using IzometriService.Core.Models.API;
using IzometriService.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using IzometriService.Business.Concrete.API;
using IzometriService.Core.Models.API.Base;

namespace IzometriService.Controllers
{
    // Startup.cs JWT Authorization
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        // GET: api/Users
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<List<UserModel>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("users")]
        public IActionResult GetUsers([FromQuery] OrderSkipTakeReq req, [FromQuery] bool isActive)
        {
            var result = _userService.GetUsers(isActive,req);
            return StatusResult(result);

        }

        // GET: api/Users/5
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<UserModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("users/{id}")]
        public IActionResult GetUsers(int id)
        {
            var result = _userService.GetUsers1(id);
            return StatusResult(result);
        }

        // PUT: api/Users/5
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("users/{id}")]
        public async Task<IActionResult> PutUsers([FromQuery] int id, [FromBody] BaseUserModel users)
        {
            var result = await _userService.PutUsers(id, users);
            return StatusResult(result);
        }

        // POST: api/Users
        //[Produces("application/json", "text/plain")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("users")]
        public async Task<IActionResult> PostUsers([FromBody] BaseUserModel users)
        {
            var result = await _userService.PostUsers(users);
            return StatusResult(result);
        }

        // DELETE: api/Users/5
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUsers([FromQuery] int id)
        {
            var result = await _userService.DeleteUsers(id);
            return StatusResult(result);
        }

 
    }
}
