using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Models;

public class GetAllIntervalsOutputModel
{
    public string? Name { get; set; }
    public int? Id { get; set; }

    public string? Title { get; set; }
    public List<ShiftsDTO> Shifts { get; set; }
    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public bool? IsDeleted { get; set; }
}