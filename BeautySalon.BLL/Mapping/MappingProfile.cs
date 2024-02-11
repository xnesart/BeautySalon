using AutoMapper;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsOutputModel>();
        CreateMap<UsersDTO, AllWorkersByRoleIdOutputModel>();

        //CreateMap<ShiftsDTO, ShiftsOutputModel>();
    }
        // CreateMap<ShiftsDTO, ShiftsInputModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    
}