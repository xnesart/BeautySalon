using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class UserRepository:IUserRepository
{
    public List<UsersDTO> GetAllEmployees()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<UsersDTO>(Procedures.GetAllEmployeesProcedure).ToList();
        }
    }
}