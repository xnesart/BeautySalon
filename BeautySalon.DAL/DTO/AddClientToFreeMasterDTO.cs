namespace BeautySalon.DAL.DTO;

public class AddClientToFreeMasterDTO
{
    public List<IntеrvalsDTO> Intervals { get; set; }
    public List<OrdersDTO> Orders { get; set; }
    public List<UsersDTO> Shifts { get; set; }
}