using AutoMapper;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.OrderModels.InputModels;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsOutputModel>();
        CreateMap<UsersDTO, GetAllWorkersByRoleIdInputModel>();
        CreateMap<UsersDTO, GetClientByNameAndIdInputModel>();
        CreateMap<NewOrderInputModel, OrdersDTO>();
    }
}
