using System.Collections.Generic;
using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IOrderRepository
{
    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id);
    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters();
    public List<OrdersByClientIdDTO> GetOrderByClientId(int clientid);
    public void UpdateOrderTimeForClientById(OrdersDTO orders);
    public void RemoveOrderForClientByOrderId(OrdersDTO order);
    public void CreateNewOrder(OrdersDTO newOrder);
    public List<GetAllOrdersOnTodayDTO> GetAllOrdersOnToday();
    public void AddClientToFreeMaster(int clientId, int serviceId, int shiftId, int intervalId);



}