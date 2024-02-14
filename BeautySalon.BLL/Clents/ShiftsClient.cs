using AutoMapper;
using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL;

public class ShiftsClient : IShiftsClient
{
    private ShiftsRepository _shiftsRepository;
    private Mapper _mapper;

    public ShiftsClient()
    {
        _shiftsRepository = new ShiftsRepository();
        var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }
    
    public List<AllShiftsOnTodayOutputModel> GetAllShiftsOnToday()
    {
        List<GetAllShiftsOnTodayDTO> shifts =
            _shiftsRepository.GetAllShiftsOnToday();
        var result = _mapper.Map<List<AllShiftsOnTodayOutputModel>>(shifts);
        return result;
    }
    public List<ShiftsWithFreeIntervalsOnCurrentServiceOutputModel> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId)
    {
        List<AllShiftsWithFreeIntervalsOnCurrentServiceDTO> shifts = this._shiftsRepository.GetAllShiftsWithFreeIntervalsOnCurrentService(serviceId);
        List<ShiftsWithFreeIntervalsOnCurrentServiceOutputModel> result = this._mapper.Map<List<ShiftsWithFreeIntervalsOnCurrentServiceOutputModel>>(shifts);

        return result;
    }

    public List<ShiftsAndEmployeesOnTodayOutputModel> GetAllShiftsAndEmployeesOnToday()
    {
        List<GetAllShiftsAndEmployeesOnTodayDTO> shifts =
            _shiftsRepository.GetAllShiftsAndEmployeesOnToday();
        var result = _mapper.Map<List<ShiftsAndEmployeesOnTodayOutputModel>>(shifts);
        return result;
    }
}