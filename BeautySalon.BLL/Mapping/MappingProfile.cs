using AutoMapper;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.NewOrderModels.InputModels;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsInputModel>();

        CreateMap<ShiftsDTO, ShiftsInputModel>();
        CreateMap<GetAllShiftsOnTodayDTO, GetAllShiftsOnTodayInputModel>();
        
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, GetAllWorkersWithContactsByUserIdInputModel>();
        
        CreateMap<RolesDTO, RolesInputModel>(); 

        CreateMap<UsersDTO, GetAllWorkersByRoleIdInputModel>();
        CreateMap<UsersDTO, GetClientByNameAndIdInputModel>();
        CreateMap<UsersDTO, GetClientByNameAndPhoneInputModel>();
        CreateMap<UsersDTO, GetMasterByNameAndIdInputModel>();
        CreateMap<UsersDTO, GetMasterByNameAndPhoneInputModel>();

        CreateMap<NewOrderInputModel, OrdersDTO>();
        CreateMap<OrdersByClientIdDTO, OrdersForClientByIdOutputModel>();
        CreateMap<UsersDTO, UsersOrdersForClientByIdOutputModel>();
        CreateMap<UsersDTO, UsersOrdersForClientByIdOutputModel>();
        CreateMap<IntеrvalsDTO, IntеrvalsOrdersForClientByIdOutputModel>();
        CreateMap<ServicesDTO, ServicesOrdersForClientByIdOutputModel>();
        CreateMap<OrdersDTO, OrdersOrdersForClientByIdOutputModel>();
    }
}

