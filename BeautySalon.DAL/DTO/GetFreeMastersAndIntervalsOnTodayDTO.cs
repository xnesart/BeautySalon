namespace BeautySalon.DAL.DTO;

public class GetFreeMastersAndIntervalsOnTodayDTO
{
    public int? MasterId { get; set; }
    public string? Master { get; set; }
    // public int? IntervalId { get; set; }
    // public string? Title { get; set; }
    // public DateTime? StartTime { get; set; }
    public List<IntеrvalsDTO>? Intervals { get; set; }
}