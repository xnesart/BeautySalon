namespace BeautySalon.DAL.DTO;

public class GetAllShiftsOnTodayDTO
{    
    public int? Id { get; set; }

    public string? Title { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

}