using System.Collections.Generic;
using AutoMapper;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Client;

public class IntervalsClient : IIntervalsClient
{
    private IntervalsRepository _intervalsRepository;
    private Mapper _mapper;

    public IntervalsClient()
    {
        _intervalsRepository = new IntervalsRepository();
        var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public List<IntervalsOutputModel> GetAllIntervals(string day)
    {
        List<IntеrvalsDTO> intervals = _intervalsRepository.GetAllIntervals(day);
        var result = _mapper.Map<List<IntervalsOutputModel>>(intervals);
        return result;
    }  
    public List<AllFreeIntervalsOnCurrentServiceOutputModel> GetAllFreeIntervalsOnCurrentService(int serviceId, int shiftId)
    {
        List<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO> intervals = _intervalsRepository.GetAllFreeIntervalsInCurrentShiftOnCurrentService(serviceId,shiftId);
        var result = _mapper.Map<List<AllFreeIntervalsOnCurrentServiceOutputModel>>(intervals);
        return result;
    }

    public List<IntervalsIdTitleStartTimeOutputModel> GetAllFreeIntervalsByShiftId(ShiftIdInputModel model)
    {
        IIntervalsRepository intervalsRepository = new IntervalsRepository();
        List<GetAllFreeIntervalsByShiftIdDTO> dto = intervalsRepository.GetAllFreeIntervalsByShiftId(model.Id);
        var result = _mapper.Map<List<IntervalsIdTitleStartTimeOutputModel>>(dto);
        return result;
    }

    // public List<MasterIdOutputModel> GetFreeMasterIdByIntervalId(IntervalIdInputModel model)
    // {
    //     IIntervalsRepository intervalsRepository = new IntervalsRepository();
    //     var newDTO = intervalsRepository.GetFreeMasterIdByIntervalId(model);
    //     var result = _mapper.Map<List<MasterIdOutputModel>>(newDTO);
    //     return result;
    // }
}