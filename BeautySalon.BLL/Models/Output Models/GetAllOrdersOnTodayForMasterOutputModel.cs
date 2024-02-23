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
        public List<ServicesDTO> Services { get; set; }
        public List<UsersDTO> Master { get; set; }
        public List<UsersDTO> Client { get; set; }
        public List<IntеrvalsDTO> Intervals { get; set; }
       
    }
}
