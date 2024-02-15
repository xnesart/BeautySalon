using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Models.Output_Models
{
    public class AllServicesByIdFromCurrentTypeOutputModel
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Duration { get; set; }

        public bool? IsDeleted { get; set; }
        public List<TypesDTO> Types { get; set; }
    }
}
