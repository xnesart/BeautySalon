--удаление процедур
drop proc AddUserByChatId
drop proc GetClientByNameAndId
drop proc GetClientByNameAndPhone
drop proc GetMasterByNameAndId
drop proc GetMasterByNameAndPhone

drop proc GetAllWorkersByRoleId

drop proc GetAllWorkersWithContactsByUserId

drop proc AddWorkerByRoleId
drop proc RemoveUserById

drop proc GetAllShiftsOnToday

drop proc GetAllShiftsAndEmployees

drop proc AddMasterToShift
drop proc RemoveMasterFromShift
drop proc GetAllIntervals
drop proc GetAllIntervalsByShiftId
drop proc GetAllShiftsWithFreeIntervals
drop proc GetAllFreeIntervalsByShiftId
drop proc GetAllServiceTypes
drop proc GetAllServicesByIdFromCurrentType
drop proc GetAllServices
drop proc AddServiceById
drop proc UpdateServiceTitle
drop proc UpdateServicePrice
drop proc UpdateServiceDuration
drop proc RemoveServiceById
drop proc AddClientToFreeMaster
drop proc GetAllOrdersOnToday
drop proc GetAllOrdersOnTodayForMasters
drop proc GetMastersShiftsById
drop proc GetMastersOrdersById
drop proc GetAllShiftsWithFreeIntervalsOnCurrentService
drop proc GetAllFreeIntervalsInCurrentShiftOnCurrentService
drop proc GetAllFreeIntervalsOnCurrentService
drop proc CreateNewOrder
drop proc GetOrdersForClientById
drop proc UpdateOrderTimeForClientById
drop proc RemoveOrderForClientByOrderId
