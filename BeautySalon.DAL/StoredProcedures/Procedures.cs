namespace BeautySalon.DAL.StoredProcedures;

public class Procedures
{
    public const string GetServiceType = "GetServiceType";
    public const string GetServicesWithPriceAndDurationByTypeId = "GetServicesWithPriceAndDurationByTypeId";
    public const string GetAllRolesProcedure = "GetAllRolesProcedure";

    public const string AddUserByChatId = "AddUserByChatId";
    public const string GetClientByNameAndId = "GetClientByNameAndId";
    public const string GetClientByNameAndPhone = "GetClientByNameAndPhone";
    public const string GetMasterByNameAndId = "GetMasterByNameAndId";
    public const string GetMasterByNameAndPhone = "GetMasterByNameAndPhone";

    public const string GetAllWorkersByRoleId = "GetAllWorkersByRoleId";

    public const string GetAllWorkersWithContactsByUserId = "GetAllWorkersWithContactsByUserId";

    public const string AddWorkerByRoleId = "AddWorkerByRoleId";
    public const string RemoveUserById = "RemoveUserById";

    //public const string GetAllShiftsOnToday = "GetAllShiftsOnToday";

    public const string GetAllShiftsAndEmployees = "GetAllShiftsAndEmployeesOnToday";

    public const string AddMasterToShift = "AddMasterToShift";
    public const string RemoveMasterFromShift = "RemoveMasterFromShift";
    public const string GetAllShiftsWithFreeIntervals = "GetAllShiftsWithFreeIntervals";
    public const string GetAllIntervalsByShiftId = "GetAllIntervalsByShiftId";

    
    
    
    public const string GetAllShiftsWithFreeIntervalsOnCurrentService = "GetAllShiftsWithFreeIntervalsOnCurrentService";
    
}