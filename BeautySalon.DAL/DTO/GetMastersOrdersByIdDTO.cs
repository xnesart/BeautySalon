namespace BeautySalon.DAL.DTO;

public class GetMastersOrdersByIdDTO
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int MasterId { get; set; }

    public int ClientId { get; set; }


    public int StartIntervalId { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsCompleted { get; set; }
    public List<UsersDTO> Master { get; set; }
    public List<IntеrvalsDTO> Intervals { get; set; }
    public List<ServicesDTO> Services { get; set; }
    public List<UsersDTO> Client { get; set; }
}