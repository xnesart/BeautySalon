using System.Collections.Generic;

namespace BeautySalon.BLL.Models;

public class MastersNameAndShiftsOutputModel
{
    public string Name { get; set; }
    public List<ShiftsOutputModel> Shifts { get; set; }
}