using AutoMapper;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<IntеrvalsDTO, IntervalsClient>();
        //CreateMap<IntеrvalsDTO, IntervalsClient>();

        CreateMap<IntеrvalsDTO, AllFreeIntervalsOnCurrentServiceOutputModel>();
        //CreateMap<ServicesD, AllFreeIntervalsOnCurrentServiceOutputModel>();
        //.ForMember(destination => destination.Type, opt => opt.MapFrom(sourse => sourse.TypeId * 5))
        //.ForMember(destination => destination.FullName, opt => opt.MapFrom(sourse => $"{sourse.TypeName} {sourse.Name}")
    }


    // CreateMap<ProductDto, ProductOneLineOutputModel>()
    // .ForMember(destination => destination.Type, opt => opt.MapFrom(sourse => sourse.TypeId*5))
    // .ForMember(destination => destination.FullName, opt => opt.MapFrom(sourse => $"{sourse.TypeName} {sourse.Name}")
    // );

}