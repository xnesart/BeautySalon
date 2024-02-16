using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Models.Output_Models
{
    public class CheckAndAddUserOutputModel
    {
        public int ChatId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }
    }
}
