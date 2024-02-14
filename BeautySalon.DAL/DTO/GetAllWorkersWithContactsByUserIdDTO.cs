namespace BeautySalon.DAL.DTO;

public class GetAllWorkersWithContactsByUserIdDTO
{
    public int? Id { get; set; }
    public int? RoleId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public List<RolesDTO> Roles { get; set; }
}