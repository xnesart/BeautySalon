using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.OrderModels.InputModels
{
    public class NewOrderInputModel
    {
        public DateTime Date { get; set; }
        public int MasterId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int StartIntervalId { get; set; }
       
    }
}
