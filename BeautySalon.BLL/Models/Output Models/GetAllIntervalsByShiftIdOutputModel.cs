namespace BeautySalon.BLL.Models;

public class GetAllIntervalsByShiftIdOutputModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public List<ShiftsOutputModel> Shifts { get; set; }

    public DateTime StartTime { get; set; }

         
}
