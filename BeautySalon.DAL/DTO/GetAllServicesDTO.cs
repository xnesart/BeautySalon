namespace BeautySalon.DAL.DTO;

public class GetAllServicesDTO
{
    public int? Id { get; set; }

    public int? TypeId { get; set; }

    public string? Title { get; set; }

    public string? Duration { get; set; }

    public decimal? Price { get; set; }

    public bool? IsDeleted { get; set; }
    public TypesDTO? Types { get; set; }
}