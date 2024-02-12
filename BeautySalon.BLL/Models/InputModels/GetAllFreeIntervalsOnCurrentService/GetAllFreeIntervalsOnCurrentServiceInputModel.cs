using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Models;

public class GetAllFreeIntervalsOnCurrentServiceInputModel
{
    public GetAllFreeIntervalsOnCurrentServiceServiceInputModel Services { get; set; }
    public  GetAllFreeIntervalsOnCurrentServiceShiftInputModel Shifts { get; set; }
    public  GetAllFreeIntervalsOnCurrentServiceIntervalModelInputModel Interval {  get; set; }
}