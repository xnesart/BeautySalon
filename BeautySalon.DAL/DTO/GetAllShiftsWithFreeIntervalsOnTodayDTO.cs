using System.Collections.Generic;

namespace BeautySalon.DAL.DTO;

public class GetAllShiftsWithFreeIntervalsOnTodayDTO
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public List<IntеrvalsDTO>? Intervals { get; set; }
}