using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IShiftsRepository
{
    public List<GetAllShiftsAndEmployeesDTO> GetAllShiftsAndEmployees();
    public List<GetAllShiftsWithFreeIntervalsDTO> GetAllShiftsWithFreeIntervals();

    
}