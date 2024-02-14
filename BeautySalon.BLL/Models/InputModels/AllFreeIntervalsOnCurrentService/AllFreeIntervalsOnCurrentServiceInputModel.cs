using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Models;

public class AllFreeIntervalsOnCurrentServiceInputModel
{
    public AllFreeIntervalsOnCurrentServiceServiceInputModel Services { get; set; }
    
    public AllFreeIntervalsOnCurrentServiceShiftInputModel Shifts { get; set; }
    
    public AllFreeIntervalsOnCurrentServiceIntervalModelInputModel Interval {  get; set; }
}