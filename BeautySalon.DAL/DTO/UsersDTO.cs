namespace BeautySalon.DAL.DTO;

public class UsersDTO
{
    public int? Id { get; set; }
    public int ClientId { get; set; }
    public List<UsersDTO> ChatId { get; set; }
    public string? UserName { get; set; }
    public string Client { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public int? RoleId { get; set; }
    public decimal? Salary { get; set; }
    public bool? IsBlocked { get; set; }
    public bool? IsDeleted { get; set; }
}