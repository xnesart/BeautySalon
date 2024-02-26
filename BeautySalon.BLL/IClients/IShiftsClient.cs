using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.IClient
{
    public interface IShiftsClient
    {
        public List<AllShiftsOnTodayOutputModel> GetAllShiftsOnToday();
        public List<ShiftsWithFreeIntervalsOnCurrentServiceOutputModel> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId);
        public List<MastersNameAndShiftsOutputModel> GetAllShiftsAndEmployeesOnToday();
        public void AddMasterToShiftWithCreatedNewIntervals(int number, int masterId);
        public List<MastersIdAndRoleIdAndNameOutputModel> GetMastersFromShiftByShiftTitle(string title);
        public void RemoveMasterFromShiftByShiftTitle(int masterId, string title);
        public List<MastersIdAndRoleIdAndNameOutputModel> GetMastersAbsentedInSelectedShift(string title);
    }
}
