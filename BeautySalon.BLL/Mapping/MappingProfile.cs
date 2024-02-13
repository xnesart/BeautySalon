using AutoMapper;
using BeautySalon.BLL.Models;
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
        //GetAllFreeIntervalsOnCurrentServiceInputModel
        CreateMap<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO, GetAllFreeIntervalsOnCurrentServiceInputModel>();
        CreateMap<ServicesDTO, GetAllFreeIntervalsOnCurrentServiceServiceInputModel>();
        CreateMap<ShiftsDTO, GetAllFreeIntervalsOnCurrentServiceShiftInputModel>();
        CreateMap<IntеrvalsDTO, GetAllFreeIntervalsOnCurrentServiceIntervalModelInputModel>();
        
        //AddWorkerByRoleId
        CreateMap<WorkerByRoleIdInputModel, AddWorkerByRoleIdDTO>();

        CreateMap<RolesDTO, RolesInputModel>(); 
        CreateMap<UsersDTO, GetAllWorkersByRoleIdInputModel>();
        CreateMap<UsersDTO, GetClientByNameAndIdInputModel>();
        CreateMap<UsersDTO, GetClientByNameAndPhoneInputModel>();
        CreateMap<UsersDTO, GetMasterByNameAndIdInputModel>();
        CreateMap<UsersDTO, GetMasterByNameAndPhoneInputModel>();

        //CreateMap<ShiftsDTO, ShiftsOutputModel>();
    }
        // CreateMap<ShiftsDTO, ShiftsInputModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    
}