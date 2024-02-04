using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
    public List<GetMastersOrdersByIdDTO> GetMastersOrdersById(int id);
    
}