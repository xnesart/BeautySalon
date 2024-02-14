using AutoMapper;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL;

public class ShiftsClient
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
}