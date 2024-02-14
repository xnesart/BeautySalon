using System.Collections.Generic;

namespace BeautySalon.BLL.Models;

public class ShiftsAndEmployeesOnTodayOutputModel
{
    public string Name { get; set; }
    public List<ShiftsOutputModel> Shifts { get; set; }
}