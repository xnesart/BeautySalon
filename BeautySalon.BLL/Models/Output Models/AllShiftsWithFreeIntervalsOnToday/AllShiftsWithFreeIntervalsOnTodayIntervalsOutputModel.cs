using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Models;

public class AllShiftsWithFreeIntervalsOnTodayIntervalsOutputModel
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public DateTime? StartTime { get; set; }
}