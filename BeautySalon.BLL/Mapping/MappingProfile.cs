using AutoMapper;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.BLL.Models.Output_Models;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsOutputModel>();
        CreateMap<UsersDTO, AllWorkersByRoleIdOutputModel>();
        CreateMap<UsersDTO, UserIsDeletedOutputModel>();
        CreateMap<ShiftsDTO, ShiftsOutputModel>();
        CreateMap<GetAllShiftsOnTodayDTO, AllShiftsOnTodayOutputModel>();
        CreateMap<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO, AllFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ServicesDTO, AllFreeIntervalsOnCurrentServiceServiceOtputModel>();
        CreateMap<ShiftsDTO, AllFreeIntervalsOnCurrentServiceShiftOutputModel>();
        CreateMap<IntеrvalsDTO, AllFreeIntervalsOnCurrentServiceIntervalModelOutputModel>();
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, AllWorkersWithContactsByUserIdOutputModel>();
        CreateMap<AddUserByChatIdInputModel, UsersDTO>();
        CreateMap<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO, AllFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ServicesDTO, AllFreeIntervalsOnCurrentServiceServiceOtputModel>();
        CreateMap<ShiftsDTO, AllFreeIntervalsOnCurrentServiceShiftOutputModel>();
        CreateMap<IntеrvalsDTO, AllFreeIntervalsOnCurrentServiceIntervalModelOutputModel>();
        CreateMap<GetAllChatIdDTO, AllChatIdOutputModel>();
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, AllWorkersWithContactsByUserIdOutputModel>();  

        CreateMap<GetAllIntervalsByShiftIdDTO, GetAllIntervalsByShiftIdOutputModel>();
        CreateMap<ShiftsDTO, ShiftsOutputModel>();


        
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, AllWorkersWithContactsByUserIdOutputModel>();   


        CreateMap<WorkerByRoleIdInputModel, AddWorkerByRoleIdDTO>();
        CreateMap<RolesDTO, RolesOutputModel>(); 
        CreateMap<UsersDTO, AllWorkersByRoleIdOutputModel>();
        CreateMap<UsersDTO, ClientByNameAndIdOutputModel>();
        CreateMap<UsersDTO, MasterByNameAndIdOutputModel>();
        CreateMap<UsersDTO, MasterByNameAndPhoneOutputModel>();
        CreateMap<UsersDTO, ClientByNameAndPhoneOutputModel>();
        CreateMap<NewOrderInputModel, OrdersDTO>();
        CreateMap<OrdersByClientIdDTO, OrdersForClientByIdOutputModel>();
        CreateMap<UsersDTO, UsersOrdersForClientByIdOutputModel>();
        CreateMap<UsersDTO, UsersOrdersForClientByIdOutputModel>();
        CreateMap<IntеrvalsDTO, IntеrvalsOrdersForClientByIdOutputModel>();
        CreateMap<ServicesDTO, ServicesOrdersForClientByIdOutputModel>();
        CreateMap<OrdersDTO, OrdersOrdersForClientByIdOutputModel>();
        CreateMap<UpdateOrderClientByIdInput, OrdersDTO>();
        CreateMap<AllShiftsWithFreeIntervalsOnCurrentServiceDTO, ShiftsWithFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ShiftsDTO, ShiftAllShiftsWithFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<RemoveOrderForClientIdInput,OrdersDTO>();
        CreateMap<GetAllShiftsAndEmployeesOnTodayDTO,ShiftsAndEmployeesOnTodayOutputModel>();
        CreateMap<ShiftsDTO,ShiftsOutputModel>();

        CreateMap<TypesDTO, AllServiceTypeOutputModel>();

        CreateMap<GetAllServicesByIdFromCurrentTypeDTO, AllServicesByIdFromCurrentTypeOutputModel>();

        CreateMap<GetAllServicesDTO, AllServicesOutputModel>();

    }
}

