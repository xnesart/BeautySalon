using System.Collections.Generic;

namespace BeautySalon.DAL.DTO;

public class GetAllShiftsAndEmployeesOnTodayDTO
{
    public string Name { get; set; }
    public List<ShiftsDTO> Shifts { get; set; }
}