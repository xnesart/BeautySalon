namespace BeautySalon.BLL.Models;

public class GetAllShiftsOnTodayInputModel
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool? IsDeleted { get; set; }
}