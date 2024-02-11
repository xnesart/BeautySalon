using AutoMapper;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.OrderModels.InputModels;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Clents
{
    public class OrderClient
    {
        private OrderRepository _orderRepository;
        private Mapper _mapper;

        public OrderClient() 
        {
            _orderRepository = new OrderRepository();
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);    
        }
        public void CreateNewOrder(OrdersInput orders)
        {

        }
        public List<OrdersByClientIdDTO> GetOrderByClientId(int clientid)
        {

        }
    }
}
