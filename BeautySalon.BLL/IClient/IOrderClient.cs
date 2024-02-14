using BeautySalon.BLL.NewOrderModels.InputModels;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.BLL.RemoveOrderForClientByOrderIInputModel;
using BeautySalon.BLL.UpdateOrderTimeForClientByIdInputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.IClient
{
    public interface IOrderClient
    {
        public void CreateNewOrder(NewOrderInputModel order);
        public List<OrdersForClientByIdOutputModel> GetOrdersForClientById(int Id);
        public void UpdateOrderTimeForClientById(UpdateOrderClientByIdInput orders);
        public void RemoveOrderForClientByOrderId(RemoveOrderForClientIdInput removeOrderForClient);
    }
}
