using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class IntervalsRepository : IIntervalsRepository
{
    public List<IntеrvalsDTO> GetAllShiftsWithFreeIntervalsOnCurrentService(int serviceId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { ServiceId = serviceId };
            return connection.Query<IntеrvalsDTO>(Procedures.GetAllShiftsWithFreeIntervalsOnCurrentService, parameters)
                .ToList();
        }
    }

    public List<GetAllIntervalsByShiftIdDTO> GetAllIntervalsByShiftId(int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { ShiftID = shiftId };
            return connection.Query<GetAllIntervalsByShiftIdDTO, ShiftsDTO, GetAllIntervalsByShiftIdDTO>(
                Procedures.GetAllIntervalsByShiftId,
                (intervals, shifts) =>
                {
                    if (intervals.Shifts == null)
                    {
                        intervals.Shifts = new List<ShiftsDTO>();
                    }

                    intervals.Shifts.Add(shifts);
                    return intervals;
                }, parameters, splitOn: "Id,Id").ToList();
        }
    }
}