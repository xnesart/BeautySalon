namespace BeautySalon.BLL.Models.Output_Models;

public class UsersByChatIdOutputModel
{
    public int? Id { get; set; }
    public int ClientId { get; set; }
    public int ChatId { get; set; }
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