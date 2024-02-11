namespace BeautySalon.DAL.DTO;

public class GetAllShiftsWithFreeIntervalsDTO
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public List<IntеrvalsDTO>? Intervals { get; set; }
}