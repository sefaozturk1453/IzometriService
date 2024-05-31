﻿using IzometriService.Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IzometriService.Api.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]//v{version:apiVersion}/
    public class BaseApiController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult StatusResult(ApiResult data) => StatusCode((int)data.StatusCode, data);

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult StatusResult<T>(ApiResult<T> data) => StatusCode((int)data.StatusCode, data);
    }
}
