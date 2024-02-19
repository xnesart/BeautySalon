using BeautySalon.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.BLL.Models.Output_Models;

namespace BeautySalon.BLL.IClient
{
    public interface IIntervalsClient
    {
        public List<IntervalsOutputModel> GetAllIntervals(string day);
        public List<AllFreeIntervalsOnCurrentServiceOutputModel> GetAllFreeIntervalsOnCurrentService(int serviceId, int shiftId);
        public List<IntervalsIdTitleStartTimeOutputModel> GetAllFreeIntervalsByShiftId(ShiftIdInputModel model);
        
        // public List<MasterIdOutputModel> GetFreeMasterIdByIntervalId(IntervalIdInputModel model);
    }
}
