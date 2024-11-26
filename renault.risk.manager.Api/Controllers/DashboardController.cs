using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController
{
    private readonly IDashboardService dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        this.dashboardService = dashboardService;
    }

    [HttpGet("cards")]
    public async Task<ObjectResult> GetInfoCards()
    {
        return new ObjectResult(await dashboardService.GetInfoCards());
    }

    [HttpGet("per-project")]
    public async Task<ObjectResult> GetRiskPerProject()
    {
        return new ObjectResult(await dashboardService.GetRiskPerProject());
    }

    [HttpGet("severity-overview")]
    public async Task<ObjectResult> GetRiskSeverityOverview()
    {
        return new ObjectResult(await dashboardService.GetRiskSeverityOverview());
    }

    [HttpGet("type-overview")]
    public async Task<ObjectResult> GetRiskTypeOverview()
    {
        return new ObjectResult(await dashboardService.GetRiskTypeOverview());
    }

    [HttpGet("activity-by-month")]
    public async Task<ObjectResult> GetRiskActivityByMonth()
    {
        return new ObjectResult(await dashboardService.GetRiskActivityByMonth());
    }
}