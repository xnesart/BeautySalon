using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.IClient
{
    public interface IShiftsClient
    {
        public List<AllShiftsOnTodayOutputModel> GetAllShiftsOnToday();
        public List<ShiftsWithFreeIntervalsOnCurrentServiceOutputModel> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId);
        public List<MastersNameAndShiftsOutputModel> GetAllShiftsAndEmployeesOnToday();
    }
}
