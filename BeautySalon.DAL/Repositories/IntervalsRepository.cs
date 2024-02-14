using System.Collections.Generic;
using System.Data;
using System.Linq;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class IntervalsRepository : IIntervalsRepository
{
   

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

    public List<GetAllFreeIntervalsByShiftIdDTO> GetAllFreeIntervalsByShiftId(int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { ShiftID = shiftId };
            return connection.Query<GetAllFreeIntervalsByShiftIdDTO>(
                Procedures.GetAllFreeIntervalsByShiftId, parameters).ToList();
        }
    }

    public List<IntеrvalsDTO> GetAllIntervals(string day)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { Day = day };
            return connection.Query<ShiftsDTO, IntеrvalsDTO, IntеrvalsDTO>(
                Procedures.GetAllIntervals,
                (shifts, intervals) =>
                {
                    if (intervals.Shifts == null)
                    {
                        intervals.Shifts = new List<ShiftsDTO>();
                    }
                    intervals.Shifts.Add(shifts);
                    return intervals;
                }, parameters, splitOn: "Id").ToList();
        }
    }
    public List<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO> GetAllFreeIntervalsInCurrentShiftOnCurrentService(int serviceId, int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                ServiceId = serviceId,
                ShiftId = shiftId
            };

            return connection.Query<ServicesDTO, ShiftsDTO, IntеrvalsDTO, GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO>
                (
                Procedures.GetAllFreeIntervalsInCurrentShiftOnCurrentService,
                (service, shift, interval) =>
                {
                    GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO getAllFree = new GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO();

                    getAllFree.Services = new ServicesDTO();
                    getAllFree.Services.Id = service.Id;
                    getAllFree.Services.Title = service.Title;

                    getAllFree.Shifts = new ShiftsDTO();
                    getAllFree.Shifts.Id = shift.Id;
                    getAllFree.Shifts.Title = shift.Title;
                    getAllFree.Shifts.StartTime = shift.StartTime;

                    getAllFree.Interval = new IntеrvalsDTO();
                    getAllFree.Interval.Id = interval.Id;
                    getAllFree.Interval.Title = interval.Title;
                    getAllFree.Interval.StartTime = interval.StartTime;

                    return getAllFree;
                },
                parameters,
                splitOn: "Id,Id,Id"
                 ).ToList();
        }
    }
}