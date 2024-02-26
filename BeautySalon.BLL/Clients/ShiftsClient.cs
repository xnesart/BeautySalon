using System.Collections.Generic;
using AutoMapper;
using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.Output_Models;
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

    public List<MastersNameAndShiftsOutputModel> GetAllShiftsAndEmployeesOnToday()
    {
        List<GetAllShiftsAndEmployeesOnTodayDTO> shifts =
            _shiftsRepository.GetAllShiftsAndEmployeesOnToday();
        var result = _mapper.Map<List<MastersNameAndShiftsOutputModel>>(shifts);
        return result;
    }

    public List<AllShiftsWithFreeIntervalsOnTodayOutputModel> GetAllShiftsWithFreeIntervalsOnToday()
    {
        List<GetAllShiftsWithFreeIntervalsOnTodayDTO> shifts =
            _shiftsRepository.GetAllShiftsWithFreeIntervalsOnToday();
        var result = _mapper.Map<List<AllShiftsWithFreeIntervalsOnTodayOutputModel>>(shifts);
        return result;
    }

    public void AddMasterToShiftWithCreatedNewIntervals(int number, int masterId)
    {
        _shiftsRepository.AddMasterToShiftWithCreatedNewIntervals(number, masterId);
    }

    public List<MastersIdAndRoleIdAndNameOutputModel> GetMastersFromShiftByShiftTitle(string title)
    {
        var shifts = _shiftsRepository.GetMastersFromShiftByShiftTitle(title);
        var result = _mapper.Map<List<MastersIdAndRoleIdAndNameOutputModel>>(shifts);
        return result;
    }

    public void RemoveMasterFromShiftByShiftTitle(int masterId, string title)
    {
        _shiftsRepository.RemoveMasterFromShiftByShiftTitle(masterId, title);
    }

    public List<MastersIdAndRoleIdAndNameOutputModel> GetMastersAbsentedInSelectedShift(string title)
    {
        var shifts = _shiftsRepository.GetMastersAbsentedInSelectedShift(title);
        var result = _mapper.Map<List<MastersIdAndRoleIdAndNameOutputModel>>(shifts);
        return result;
    }
}