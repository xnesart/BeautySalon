namespace BeautySalon.DAL.DTO;

public class AddMasterToShiftWithIntervalsByShiftNumberDTO
{
    public List<UsersDTO>? Users { get; set; }
    // public int? Number { get; set; }
    // public string? Title { get; set; }
    // public DateTime? StartTime { get; set; }
    // public DateTime? EndTime { get; set; }
    // public int? MasterId { get; set; }
    // public bool? IsDeleted { get; set; }
    // public int? ShiftId { get; set; }
    // public int? ShiftNumber { get; set; }
    // public string? ShiftTitle { get; set; }
    public List<IntеrvalsDTO>? Intervals { get; set; }
}