using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Models.Output_Models
{
    public class GetOrdersByMasterIdOutputModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int IntervalId { get; set; }

        public string IntervalTitle { get; set; }

        public UsersDTO Client { get; set; }
        public UsersDTO Master { get; set; }
        public ServicesDTO Services { get; set; }
    }
}
