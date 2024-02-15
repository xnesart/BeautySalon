using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Models.InputModels
{
    public class AllServiceTypeOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

