using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.DTO
{
    public class OrdersByClientIdDTO
    {
        public UsersDTO Master { get; set; }
        public UsersDTO Client { get; set; }
        public int MasterId { get; set; }
        public DateTime Date { get; set; }
        public int StartIntervalId { get; set; }
        public IntеrvalsDTO Interval { get; set; }
        public ServicesDTO Service { get; set; }
        public OrdersDTO Order { get; set; }
    }
}
