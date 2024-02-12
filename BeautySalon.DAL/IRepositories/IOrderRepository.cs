using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id);
    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters();
    public List<OrdersByClientIdDTO> GetOrderByClientId(int clientid);
    public void UpdateOrderTimeForClientById(int orderId, int clientId, int masterId, int intervalId);
    public void RemoveOrderForClientByOrderId(int orderId);
    public void CreateNewOrder(OrdersDTO newOrder);
    public List<GetAllOrdersOnTodayDTO> GetAllOrdersOnToday();
    public void AddClientToFreeMaster(int clientId, int serviceId, int shiftId, int intervalId);



}