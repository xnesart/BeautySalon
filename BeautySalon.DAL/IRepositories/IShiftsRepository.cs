using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IShiftsRepository
{
    public List<GetAllShiftsOnTodayDTO> GetAllShiftsOnToday();
    public List<GetAllShiftsAndEmployeesDTO> GetAllShiftsAndEmployeesOnToday();
    public List<GetAllShiftsWithFreeIntervalsDTO> GetAllShiftsWithFreeIntervals();
    public List<AllShiftsWithFreeIntervalsOnCurrentServiceDTO> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId);
}