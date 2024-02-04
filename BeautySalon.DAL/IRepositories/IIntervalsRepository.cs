using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IIntervalsRepository
{
    public List<IntеrvalsDTO> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId);
    public List<GetAllIntervalsByShiftIdDTO> GetAllIntervalsByShiftId(int shiftId);
    public List<GetAllFreeIntervalsByShiftIdDTO> GetAllFreeIntervalsByShiftId(int shiftId);
    
}