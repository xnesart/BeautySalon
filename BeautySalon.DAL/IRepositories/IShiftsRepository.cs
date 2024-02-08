using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IShiftsRepository
{
    public List<GetAllShiftsOnToday> GetAllShiftsOnToday();
    public List<GetAllShiftsAndEmployeesDTO> GetAllShiftsAndEmployeesOnToday();
    public List<GetAllShiftsWithFreeIntervalsDTO> GetAllShiftsWithFreeIntervals();
}