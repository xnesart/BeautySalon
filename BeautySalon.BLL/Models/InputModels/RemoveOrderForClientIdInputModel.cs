using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Models.InputModels
{
    public class RemoveOrderForClientIdInput
    {
        public int ClientId { get; set; }
        public int OrderId { get; set; }
    }
}
