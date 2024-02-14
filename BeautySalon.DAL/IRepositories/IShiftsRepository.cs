using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IShiftsRepository
{
    public List<GetAllShiftsOnTodayDTO> GetAllShiftsOnToday();
    public List<GetAllShiftsAndEmployeesDTO> GetAllShiftsAndEmployeesOnToday();
<<<<<<< HEAD
    public List<GetAllShiftsWithFreeIntervalsOnTodayDTO> GetAllShiftsWithFreeIntervalsOnToday();
=======
    public List<GetAllShiftsWithFreeIntervalsDTO> GetAllShiftsWithFreeIntervals();
    public List<AllShiftsWithFreeIntervalsOnCurrentServiceDTO> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId);
>>>>>>> TatianaYstinova/main
}