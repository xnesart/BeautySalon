using AutoMapper;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsClient>();
        CreateMap<IntеrvalsDTO, IntervalsClient>();
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