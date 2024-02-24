using System.Collections.Generic;
using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IShiftsRepository
{
    public List<GetAllShiftsOnTodayDTO> GetAllShiftsOnToday();
    public List<GetAllShiftsAndEmployeesOnTodayDTO> GetAllShiftsAndEmployeesOnToday();
    public List<GetAllShiftsWithFreeIntervalsOnTodayDTO> GetAllShiftsWithFreeIntervalsOnToday();
    public List<AllShiftsWithFreeIntervalsOnCurrentServiceDTO> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId);
    public List<AddMasterToShiftWithCreatedNewIntervalsDTO> AddMasterToShiftWithCreatedNewIntervals(int number, int masterId);
    public List<GetMastersFromShiftByShiftTitleDTO> GetMastersFromShiftByShiftTitle(string title);
    public void RemoveMasterFromShiftByShiftTitle(int masterId, string title);
}