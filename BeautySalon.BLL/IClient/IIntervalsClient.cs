using BeautySalon.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.IClient
{
    public interface IIntervalsClient
    {
        public List<IntervalsOutputModel> GetAllIntervals(string day);
        public List<AllFreeIntervalsOnCurrentServiceOutputModel> GetAllFreeIntervalsOnCurrentService(int serviceId, int shiftId);
    }
}
