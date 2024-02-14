using System.Collections.Generic;

namespace BeautySalon.BLL.Models;

public class AllWorkersWithContactsByUserIdOutputModel
{
    public int? Id { get; set; }
    public int? RoleId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public List<RolesOutputModel> Roles { get; set; }
}