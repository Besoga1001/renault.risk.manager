using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/log")]
public class GlobalLogsController
{
    private readonly IGlobalLogService globalLogService;

    public GlobalLogsController(IGlobalLogService globalLogService)
    {
        this.globalLogService = globalLogService;
    }

    [HttpGet]
    public async Task<ObjectResult> GetAllAsync([FromQuery] string? filterLogOptionsEnums)
    {
        var response = await globalLogService.GetAllAsync(filterLogOptionsEnums);
        return new ObjectResult(response);
    }

    [HttpGet("solution")]
    public async Task<ObjectResult> GetBySolutionAsync()
    {
        var response = await globalLogService.GetBySolutionAsync();
        return new ObjectResult(response);
    }

    [HttpGet("field-options")]
    public ObjectResult GetFieldOptions()
    {
        return new OkObjectResult(globalLogService.GetFieldOptions());
    }

}