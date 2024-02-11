using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id);
    public List<OrdersDTO> RemoveOrderForClientByOrderId(int orderId);
    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters();
    public List<OrdersByClientIdDTO> GetOrderByClientId(int clientId);
    public List<GetAllOrdersOnTodayDTO> GetAllOrdersOnToday();
    public void AddClientToFreeMaster(int clientId, int serviceId, int shiftId, int intervalId);

}