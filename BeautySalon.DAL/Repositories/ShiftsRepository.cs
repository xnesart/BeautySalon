using System.Collections.Generic;
using System.Data;
using System.Linq;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class ShiftsRepository : IShiftsRepository
{
    public List<GetAllShiftsOnTodayDTO> GetAllShiftsOnToday()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllShiftsOnTodayDTO>(
                Procedures.GetAllShiftsAndEmployeesOnToday).ToList();
        }
    }    
    
    public List<GetAllShiftsAndEmployeesOnTodayDTO> GetAllShiftsAndEmployeesOnToday()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllShiftsAndEmployeesOnTodayDTO, ShiftsDTO, GetAllShiftsAndEmployeesOnTodayDTO>(
                Procedures.GetAllShiftsAndEmployeesOnToday,
                (users, shifts) =>
                {
                    if (users.Shifts == null)
                    {
                        users.Shifts = new List<ShiftsDTO>();
                    }

                    users.Shifts.Add(shifts);
                    return users;
                }, splitOn: "Name,Id").ToList();
        }
    }

    public List<GetAllShiftsWithFreeIntervalsOnTodayDTO> GetAllShiftsWithFreeIntervalsOnToday()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllShiftsWithFreeIntervalsOnTodayDTO, IntеrvalsDTO, GetAllShiftsWithFreeIntervalsOnTodayDTO>(
                Procedures.GetAllShiftsWithFreeIntervalsOnToday,
                (shifts, intervals) =>
                {
                    if (shifts.Intervals == null)
                    {
                        shifts.Intervals = new List<IntеrvalsDTO>();
                    }
                    shifts.Intervals.Add(intervals);
                    return shifts;
                }, splitOn: "Id,StartTime").ToList();
        }
    }
    public List<AllShiftsWithFreeIntervalsOnCurrentServiceDTO> GetAllShiftsWithFreeIntervalsOnCurrentService (int serviceId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {

            var parameter = new
            {
                ServiceId = serviceId,
            };

            return connection.Query<ServicesDTO, ShiftsDTO, AllShiftsWithFreeIntervalsOnCurrentServiceDTO>
                (
                Procedures.GetAllShiftsWithFreeIntervalsOnCurrentService,
                (service, shift) =>
                {
                    AllShiftsWithFreeIntervalsOnCurrentServiceDTO getAllShifts = new AllShiftsWithFreeIntervalsOnCurrentServiceDTO();

                    getAllShifts.Services = new ServicesDTO();
                    getAllShifts.Services.Id = service.Id;
                    getAllShifts.Services.Title = service.Title;

                    getAllShifts.Shift = new ShiftsDTO();
                    getAllShifts.Shift.Id = shift.Id;
                    getAllShifts.Shift.Title = shift.Title;
                    getAllShifts.Shift.StartTime = shift.StartTime;

                    return getAllShifts;
                },
                parameter ,
                splitOn: "Id,Id"
                ).ToList();
        }
    }
}