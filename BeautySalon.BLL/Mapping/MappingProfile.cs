using AutoMapper;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<IntеrvalsDTO, IntervalsClient>();
        CreateMap<ShiftsDTO,AllIntervalsInputModel>().ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest => dest.Title,opt=>opt.MapFrom(src=>src.Title));
    }

    // CreateMap<ProductInputModel, ProductDto>();
    //
    // CreateMap<ProductDto, ProductWithTypeOutputModel>();
    //
    // CreateMap<ProductTypeDto, ProductTypeOutputModel>();
    //
    // CreateMap<ProductDto, ProductOneLineOutputModel>()
    // .ForMember(destination => destination.Type, opt => opt.MapFrom(sourse => sourse.TypeId*5))
    // .ForMember(destination => destination.FullName, opt => opt.MapFrom(sourse => $"{sourse.TypeName} {sourse.Name}")
    // );
}