using AutoMapper;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL;

public class IntervalsClient
{
    private IntervalsRepository _intervalsRepository;
    private Mapper _mapper;

    public IntervalsClient()
    {
        _intervalsRepository = new IntervalsRepository();
        var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    

    public List<IntervalsInputModel> GetAllIntervals(string day)
    {
        List<IntеrvalsDTO> intervals = _intervalsRepository.GetAllIntervals(day);
        var result = _mapper.Map<List<IntervalsInputModel>>(intervals);
        return result;
    }
}