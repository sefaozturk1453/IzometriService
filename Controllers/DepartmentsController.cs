using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using IzometriService.Api.Controllers.Base;
using IzometriService.Business.Abstract.API;
using IzometriService.Core.Models.API.Base;
using IzometriService.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using IzometriService.Core.Models.API;
using System.Collections.Generic;
using IzometriService.Entities.Concrete;

namespace IzometriService.Controllers
{
    // Startup.cs JWT Authorization
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<List<DepartmentModel>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("department")]
        public async Task<IActionResult> GetDepartments([FromQuery] OrderSkipTakeReq req)
        {
            var result = await _departmentService.GetDepartments(req);
            return StatusResult(result);

        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<DepartmentModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("department/{id}")]
        public async Task<IActionResult> GetDepartments(int id)
        {
            var result = await _departmentService.GetDepartments1(id);
            return StatusResult(result);
        }

        // PUT: api/Departments/5
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("department/{id}")]
        public async Task<IActionResult> PutDepartments([FromQuery] int id, [FromBody] BaseDepartmentModel departments)
        {
            var result = await _departmentService.PutDepartments(id, departments);
            return StatusResult(result);
        }

        // POST: api/Departments
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("department")]
        public async Task<IActionResult> PostDepartments(BaseDepartmentModel departments)
        {
            var result = await _departmentService.PostDepartments( departments);
            return StatusResult(result);
        }

        // DELETE: api/Departments/5
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("department/{id}")]
        public async Task<IActionResult> DeleteDepartments([FromQuery] int id)
        {
            var result = await _departmentService.DeleteDepartments(id);
            return StatusResult(result);
        }
    }
}
