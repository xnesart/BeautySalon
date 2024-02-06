namespace BeautySalon.DAL.DTO;

public class GetMastersShiftsById
{
    public int MasterId { get; set; }
    public string Master { get; set; }
    public List<ShiftsDTO> Shifts { get; set; }
}