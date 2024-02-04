namespace BeautySalon.DAL.DTO;

public class GetAllShiftsAndEmployeesDTO
{
    public string Name { get; set; }
    public List<ShiftsDTO> Shifts { get; set; }
}