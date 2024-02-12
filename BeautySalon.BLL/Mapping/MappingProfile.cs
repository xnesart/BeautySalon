using AutoMapper;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.OrderModels.InputModels;
using BeautySalon.DAL.DTO;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsInputModel>();
        CreateMap<ShiftsDTO, ShiftsInputModel>();
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, GetAllWorkersWithContactsByUserIdInputModel>();
        CreateMap<GetAllShiftsOnTodayDTO, GetAllShiftsOnTodayInputModel>();
        CreateMap<RolesDTO, RolesInputModel>(); 
        CreateMap<UsersDTO, GetAllWorkersByRoleIdInputModel>();
        CreateMap<UsersDTO, GetClientByNameAndIdInputModel>();
        CreateMap<NewOrderInputModel, OrdersDTO>();
        CreateMap<UsersDTO, GetClientByNameAndPhoneInputModel>();
        CreateMap<UsersDTO, GetMasterByNameAndIdInputModel>();
        CreateMap<UsersDTO, GetMasterByNameAndPhoneInputModel>();

        //CreateMap<ShiftsDTO, ShiftsOutputModel>();
    }
}
