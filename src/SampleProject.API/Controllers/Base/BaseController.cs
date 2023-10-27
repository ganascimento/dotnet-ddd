using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SampleProject.Application.Utils;

namespace SampleProject.API.Controllers.Base;

public class BaseController : ODataController
{
    protected IActionResult HandleResult(ResponseService responseService)
    {
        if (responseService.Success)
            return Ok(responseService);

        return BadRequest(responseService);
    }
}