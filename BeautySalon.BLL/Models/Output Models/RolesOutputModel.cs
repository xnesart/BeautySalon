namespace BeautySalon.BLL.Models;

public class RolesOutputModel
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string? Worker { get; set; }

    public bool? IsDeleted { get; set; } 
}