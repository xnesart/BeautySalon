using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.OrdersForClientById
{
    public class OrdersForClientByIdOutputModel
    {
        public UsersOrdersForClientByIdOutputModel Master { get; set; }
        public UsersOrdersForClientByIdOutputModel Client { get; set; }
        public IntеrvalsOrdersForClientByIdOutputModel Interval { get; set; }
        public ServicesOrdersForClientByIdOutputModel Service { get; set; }
        public OrdersOrdersForClientByIdOutputModel Order { get; set; }
    }
}
