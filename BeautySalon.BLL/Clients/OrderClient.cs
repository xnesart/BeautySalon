using System.Collections.Generic;
using AutoMapper;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Clients
{
    public class OrderClient : IOrderClient
    {
        private IOrderRepository _orderRepository;
        private Mapper _mapper;

        public OrderClient()
        {
            _orderRepository = new OrderRepository();
            IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }
        public void CreateNewOrder(NewOrderInputModel order)
        {
            OrdersDTO newOrder = this._mapper.Map<OrdersDTO>(order);
            this._orderRepository.CreateNewOrder(newOrder);
        }
        public List<OrdersForClientByIdOutputModel> GetOrdersForClientById(int Id)
        {
            List<OrdersByClientIdDTO> orders = this._orderRepository.GetOrderByClientId(Id);
            List<OrdersForClientByIdOutputModel> result = this._mapper.Map<List<OrdersForClientByIdOutputModel>>(orders);

            return result;
        }
        public void UpdateOrderTimeForClientById(UpdateOrderClientByIdInput orders)
        {
            OrdersDTO ordersDTO = this._mapper.Map<OrdersDTO>(orders);
            this._orderRepository.UpdateOrderTimeForClientById(ordersDTO);
        }
        public void RemoveOrderForClientByOrderId(RemoveOrderForClientIdInput removeOrderForClient)
        {
            OrdersDTO orders = this._mapper.Map<OrdersDTO>(removeOrderForClient);
            this._orderRepository.RemoveOrderForClientByOrderId(orders);
        }
        public List<GetAllOrdersOnTodayForMasterOutputModel> GetAllOrdersOnTodayForMasters()
        {
            List<GetAllOrdersOnTodayForMasterDTO> getAllOrdersOnToday = _orderRepository.GetAllOrdersOnTodayForMaster();
            List<GetAllOrdersOnTodayForMasterOutputModel> result = this._mapper.Map<List<GetAllOrdersOnTodayForMasterOutputModel>>(getAllOrdersOnToday);
            return result;
        }
    }
}
