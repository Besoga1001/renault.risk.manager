using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.ResponseDTOs.Home;

namespace renault.risk.manager.Application.Services;

public class HomeService : IHomeService
{
    private readonly IRiskRepository riskRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public HomeService(IRiskRepository riskRepository)
    {
        this.riskRepository = riskRepository;
    }

    public async Task<CardsHomeResponseDTO> GetInfoCards()
    {
        var firstWeekDay = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek);
        var lastWeekDay = firstWeekDay.AddDays(6);
        var firstMonthDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var lastMonthDay = firstMonthDay.AddMonths(1).AddDays(-1);

        var riskEntities = await riskRepository.GetAllAsync();

        return new CardsHomeResponseDTO
        {
            WeeklyRisk = riskEntities.GetWeelkyRisks(firstWeekDay, lastWeekDay),
            ResolvedMonthlyRisks = riskEntities.GetMonthRisks(true, firstMonthDay, lastMonthDay),
            NoResolvedMonthlyRisks = riskEntities.GetMonthRisks(false, firstMonthDay, lastMonthDay),
            TotalCriticalRisks = riskEntities.GetTotalCriticalRisks()
        };
    }


}