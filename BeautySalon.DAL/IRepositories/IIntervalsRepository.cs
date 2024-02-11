using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IIntervalsRepository
{
    public List<IntеrvalsDTO> GetAllShiftsWithFreeIntervalsOnCurrentService(int shiftId,int serviceId);
    public List<GetAllIntervalsByShiftIdDTO> GetAllIntervalsByShiftId(int shiftId);
    public List<GetAllFreeIntervalsByShiftIdDTO> GetAllFreeIntervalsByShiftId(int shiftId);

    public List<IntеrvalsDTO> GetAllIntervals(string day);
    
    // public List<AddClientToFreeMasterDTO> AddClientToFreeMaster(int clientId, int serviceId, int shiftId, int intervalId, string date);
    
}