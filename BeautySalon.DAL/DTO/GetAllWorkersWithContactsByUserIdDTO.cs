namespace BeautySalon.DAL.DTO;

public class GetAllWorkersWithContactsByUserIdDTO
{
    public int? WorkerId { get; set; }
    public int? WorkerRoleId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public List<RolesDTO> Roles { get; set; }
}