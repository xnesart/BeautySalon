using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Models.Output_Models
{
    public class GetAllOrdersOnTodayForMasterOutputModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ServicesDTO Services { get; set; }
        public UsersDTO Master { get; set; }
        public UsersDTO Client { get; set; }
        public IntеrvalsDTO Intervals { get; set; }
        public OrdersDTO Orders { get; set; } 
       
    }
}
