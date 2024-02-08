using System.Data;
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
            return connection.Query<GetAllShiftsOnTodayDTO, ShiftsDTO, GetAllShiftsOnTodayDTO>(
                Procedures.GetAllShiftsAndEmployeesOnToday,
                (allShifts, shifts) =>
                {
                    if (allShifts.Shifts == null)
                    {
                        allShifts.Shifts = new List<ShiftsDTO>();
                    }

                    allShifts.Shifts.Add(shifts);
                    return allShifts;
                }).ToList();
        }
    }    
    
    public List<GetAllShiftsAndEmployeesDTO> GetAllShiftsAndEmployeesOnToday()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllShiftsAndEmployeesDTO, ShiftsDTO, GetAllShiftsAndEmployeesDTO>(
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

    public List<GetAllShiftsWithFreeIntervalsDTO> GetAllShiftsWithFreeIntervals()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllShiftsWithFreeIntervalsDTO, IntеrvalsDTO, GetAllShiftsWithFreeIntervalsDTO>(
                Procedures.GetAllShiftsWithFreeIntervals,
                (shifts, intervals) =>
                {
                    if (shifts.Intervals == null)
                    {
                        shifts.Intervals = new List<IntеrvalsDTO>();
                    }

                    shifts.Intervals.Add(intervals);
                    return shifts;
                }, splitOn: "Id,IsBusy").ToList();
        }
    }
}