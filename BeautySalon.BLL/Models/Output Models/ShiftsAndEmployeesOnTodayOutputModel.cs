namespace BeautySalon.BLL.Models;

public class ShiftsAndEmployeesOnTodayOutputModel
{
    public string Name { get; set; }
    public List<ShiftsInputModel> Shifts { get; set; }
}