using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
<<<<<<< HEAD
    public List<GetMastersOrdersByIdDTO> GetMastersOrdersById(int id);
    
=======
    public List<OrdersDTO> RemoveOrderForClientByOrderId(int orderId);
>>>>>>> f3482d634fcb4061a292b6d34c9fc9176a0a3fca
}