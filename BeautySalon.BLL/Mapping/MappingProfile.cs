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
        CreateMap<GetAllChatIdDTO, AllChatIdOutputModel>();
        CreateMap<GetAllIntervalsByShiftIdDTO, GetAllIntervalsByShiftIdOutputModel>();
        CreateMap<WorkerByRoleIdInputModel, AddWorkerByRoleIdDTO>();
        CreateMap<RolesDTO, RolesOutputModel>(); 
        CreateMap<UsersDTO, ClientByNameAndIdOutputModel>();
        CreateMap<UsersDTO, MasterByNameAndIdOutputModel>();
        CreateMap<UsersDTO, MasterByNameAndPhoneOutputModel>();
        CreateMap<UsersDTO, ClientByNameAndPhoneOutputModel>();
        CreateMap<NewOrderInputModel, OrdersDTO>();
        CreateMap<OrdersByClientIdDTO, OrdersForClientByIdOutputModel>();
        CreateMap<UsersDTO, UsersOrdersForClientByIdOutputModel>();
        CreateMap<IntеrvalsDTO, IntеrvalsOrdersForClientByIdOutputModel>();
        CreateMap<ServicesDTO, ServicesOrdersForClientByIdOutputModel>();
        CreateMap<OrdersDTO, OrdersOrdersForClientByIdOutputModel>();
        CreateMap<UpdateOrderClientByIdInput, OrdersDTO>();
        CreateMap<AllShiftsWithFreeIntervalsOnCurrentServiceDTO, ShiftsWithFreeIntervalsOnCurrentServiceOutputModel>();
        CreateMap<ShiftsDTO, ShiftAllShiftsWithFreeIntervalsOnCurrentServiceOutputModel>();

        CreateMap<RemoveOrderForClientIdInput, OrdersDTO>()
        .ForMember(destination => destination.Id, sourse => sourse.MapFrom(opt => opt.OrderId));

        CreateMap<GetAllShiftsAndEmployeesOnTodayDTO,MastersNameAndShiftsOutputModel>();
        CreateMap<MasterIdAndShiftIdInputModel,ShiftsDTO>();
        CreateMap<GetAllFreeIntervalsByShiftIdDTO,IntervalsIdTitleStartTimeOutputModel>();
        CreateMap<GetAllShiftsWithFreeIntervalsOnTodayDTO,AllShiftsWithFreeIntervalsOnTodayOutputModel>();
        CreateMap<IntеrvalsDTO,AllShiftsWithFreeIntervalsOnTodayIntervalsOutputModel>();
        CreateMap<ServiceByIdInputModel, AddServiceByIdDTO>();
        CreateMap<TypesDTO, AllServiceTypeOutputModel>();
        CreateMap<GetAllServicesByIdFromCurrentTypeDTO, AllServicesByIdFromCurrentTypeOutputModel>();
        CreateMap<GetAllServicesDTO, AllServicesOutputModel>();
        CreateMap<UsersDTO,CheckAndAddUserOutputModel>();
        CreateMap<MasterIdAndShiftNumberInputModel,ShiftsDTO>();
        CreateMap<ServiceIdAndServiceTitleInputModel,UpdateServiceTitleDTO>();
        CreateMap<UsersDTO,UserByChatIdOutputModel>();
        CreateMap<ServiceIdAndServicePriceInputModel,UpdateServicePriceDTO>();
        CreateMap<ServiceIdAndServiceDurationInputModel,UpdateServiceDurationDTO>();
        CreateMap<ServicesDTO, ServiceIsDeletedOutputModel>();
        CreateMap<GetFreeMasterIdByIntervalIdDTO, MasterIdOutputModel>();
        CreateMap<GetWorkerNameByPasswordDTO, NameOutputModel>();
        CreateMap<PasswordChatIdUserNameInputModel, ChangeChatIdAndUserNameByPasswordDTO>();
        CreateMap<GetAllOrdersOnTodayForMasterDTO, GetAllOrdersOnTodayForMasterOutputModel>();
        CreateMap<GetOrdersByMasterId, GetOrdersByMasterIdOutputModel>();
        CreateMap<GetMastersFromShiftByShiftTitleDTO, MastersIdAndRoleIdAndNameOutputModel>();
        CreateMap<MasterIdAndShiftTitleInputModel, RemoveMasterFromShiftByShiftTitleDTO>();
        CreateMap<GetWorkerNameAndChatIdAndIdByPasswordDTO, WorkerNameAndChatIdAndIdByPasswordOutputModel>();
    }
}

