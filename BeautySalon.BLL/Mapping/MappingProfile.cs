using AutoMapper;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.NewOrderModels.InputModels;
using BeautySalon.DAL.DTO;
using BeautySalon.BLL.UpdateOrderTimeForClientByIdInputModel;
using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.RemoveOrderForClientByOrderIInputModel;

namespace BeautySalon.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IntеrvalsDTO, IntervalsOutputModel>();

        CreateMap<ShiftsDTO, ShiftsInputModel>();

        
        //GetAllShiftsOnToday
        CreateMap<GetAllShiftsOnTodayDTO, AllShiftsOnTodayOutputModel>();
        
        //GetAllFreeIntervalsOnCurrentServiceInputModel
        CreateMap<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO, AllFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ServicesDTO, AllFreeIntervalsOnCurrentServiceServiceOtputModel>();
        CreateMap<ShiftsDTO, AllFreeIntervalsOnCurrentServiceShiftOutputModel>();
        CreateMap<IntеrvalsDTO, AllFreeIntervalsOnCurrentServiceIntervalModelOutputModel>();

        //AllWorkersWithContactsByUser
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, AllWorkersWithContactsByUserIdOutputModel>();


        
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, AllWorkersWithContactsByUserIdOutputModel>();

        CreateMap<GetAllShiftsOnTodayDTO, AllShiftsOnTodayOutputModel>();
        CreateMap<AddUserByChatIdInputModel, UsersDTO>();

        CreateMap<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO, AllFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ServicesDTO, AllFreeIntervalsOnCurrentServiceServiceOtputModel>();
        CreateMap<ShiftsDTO, AllFreeIntervalsOnCurrentServiceShiftOutputModel>();
        CreateMap<IntеrvalsDTO, AllFreeIntervalsOnCurrentServiceIntervalModelOutputModel>();
        //GetAllChatId
        CreateMap<GetAllChatIdDTO, AllChatIdOutputModel>();
        CreateMap<GetAllIntervalsByShiftIdDTO, GetAllIntervalsByShiftIdOutputModel>();
        CreateMap<ShiftsDTO, ShiftsOutputModel>();


        
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, AllWorkersWithContactsByUserIdOutputModel>();   

        CreateMap<WorkerByRoleIdInputModel, AddWorkerByRoleIdDTO>();

        CreateMap<RolesDTO, RolesInputModel>(); 

        CreateMap<UsersDTO, AllWorkersByRoleIdOutputModel>();
        //GetClientByNameAndId
        CreateMap<UsersDTO, ClientByNameAndIdOutputModel>();
        //GetMasterByNameAndId
        CreateMap<UsersDTO, MasterByNameAndIdOutputModel>();
        //GetMasterByNameAndPhone
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

    }
}

