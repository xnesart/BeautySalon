using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Models;

public class AllShiftsWithFreeIntervalsOnTodayOutputModel
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public List<AllShiftsWithFreeIntervalsOnTodayIntervalsOutputModel>? Intervals { get; set; }
}