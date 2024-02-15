using System.Collections.Generic;

namespace BeautySalon.DAL.DTO;

public class GetAllServicesByIdFromCurrentTypeDTO
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Duration { get; set; }

    public bool? IsDeleted { get; set; }
    public List<TypesDTO> Types { get; set; }
}