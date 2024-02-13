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
        CreateMap<IntеrvalsDTO, IntervalsInputModel>();

        CreateMap<ShiftsDTO, ShiftsInputModel>();
        CreateMap<GetAllShiftsOnTodayDTO, GetAllShiftsOnTodayInputModel>();

        CreateMap<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO, GetAllFreeIntervalsOnCurrentServiceInputModel>();
        CreateMap<ServicesDTO, GetAllFreeIntervalsOnCurrentServiceServiceInputModel>();
        CreateMap<ShiftsDTO, GetAllFreeIntervalsOnCurrentServiceShiftInputModel>();
        CreateMap<IntеrvalsDTO, GetAllFreeIntervalsOnCurrentServiceIntervalModelInputModel>();

        
        CreateMap<GetAllWorkersWithContactsByUserIdDTO, GetAllWorkersWithContactsByUserIdInputModel>();   

        CreateMap<WorkerByRoleIdInputModel, AddWorkerByRoleIdDTO>();

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

        CreateMap<UpdateOrderClientByIdInput, OrdersDTO>();

        CreateMap<AllShiftsWithFreeIntervalsOnCurrentServiceDTO, ShiftsWithFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ShiftsDTO, ShiftAllShiftsWithFreeIntervalsOnCurrentServiceOutputModel>();

        CreateMap<RemoveOrderForClientIdInput,OrdersDTO>();

    }
}

