using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

//public class ShiftsRepository : IShiftsRepository
//{
//    public List<GetAllShiftsAndEmployeesDTO> GetAllShiftsAndEmployees()
//    {
//        //using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
//        //{
//        //    return connection.Query<GetAllShiftsAndEmployeesDTO, ShiftsDTO, GetAllShiftsAndEmployeesDTO>(
//        //        Procedures.GetAllShiftsAndEmployees,
//        //        (users, shifts) =>
//        //        {
//        //            if (users.Shifts == null)
//        //            {
//        //                users.Shifts = new List<ShiftsDTO>();
//        //            }
//        //            users.Shifts.Add(shifts);
//        //            return users;
//        //        }, splitOn:"Name,Id").ToList();
//        //}
//    }
//}