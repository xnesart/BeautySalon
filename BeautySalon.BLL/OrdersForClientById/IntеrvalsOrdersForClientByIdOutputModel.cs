using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class IntеrvalsOrdersForClientByIdOutputModel
    {
        public string Title { get; set; }

        public List<ShiftsDTO> Shifts { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsBusy { get; set; }
    }
