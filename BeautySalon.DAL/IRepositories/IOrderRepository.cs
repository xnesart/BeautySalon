using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id);
    
    public List<OrdersDTO> RemoveOrderForClientByOrderId(int orderId);
    
    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters();
    public List<OrdersByClientIdDTO> GetOrderByClientId(int clientid);
    
    public List<GetAllOrdersOnTodayDTO> GetAllOrdersOnToday();



}