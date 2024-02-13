using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.UpdateOrderTimeForClientByIdInputModel
{
    public class UpdateOrderClientByIdInput
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ClientId { get; set; }
        public int IntervalId { get; set; }
    }
}
