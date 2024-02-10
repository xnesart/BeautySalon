using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id);
    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters();
    public List<OrdersByClientIdDTO> GetOrderByClientId(int clientid);
    public void UpdateOrderTimeForClientById(int orderId, int clientId, int masterId, int intervalId);
    
    public void RemoveOrderForClientByOrderId(int orderId);
    
    public void CreateNewOrder(int clientId, int masterId, DateTime date, int serviceId, int intervalId);




}