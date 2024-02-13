using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.CreateGetOrdersForClientByIdOutputModel
{
    public class OrdersForClientByIdOutputModel
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


//public int OdrerId { get; set; }
//public string OdrerDate { get; }
//public int OdrerStartIntervalId { get; set; }
//public int ClientId { get; set; }
//public string ClientName { get; set; }
//public int MasterId { get; set; }
//public string MasterName { get; set; }
//public int IntervalsId { get; set; }
//public string IntervalTitle { get; set; }
//public int ServicesId { get; set; }
//public string ServicesTitle { get; set; }
//public decimal ServicesPrice { get; set; }