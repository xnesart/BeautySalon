namespace BeautySalon.BLL.Models;

public class IntervalsInputModel
{
    public string? Name { get; set; }
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool? IsDeleted { get; set; }
}