using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Models;

public class AllFreeIntervalsOnCurrentServiceOutputModel
{
    public AllFreeIntervalsOnCurrentServiceServiceOtputModel Services { get; set; }
    
    public AllFreeIntervalsOnCurrentServiceShiftOutputModel Shifts { get; set; }
    
    public AllFreeIntervalsOnCurrentServiceIntervalModelOutputModel Interval {  get; set; }
}