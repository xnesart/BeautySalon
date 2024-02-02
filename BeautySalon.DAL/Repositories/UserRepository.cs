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
    public List<UsersDTO> GetClientByNameAndId(string name, int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Id = id,
                Name = name
            };
            return connection.Query<UsersDTO>(Procedures.GetClientByNameAndId, parameters).ToList();
        }
    }

    public List<UsersDTO> GetClientByNameAndPhone(string name, string phone)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Name = name,
                Phone = phone
            };
            return connection.Query<UsersDTO>(Procedures.GetClientByNameAndPhone, parameters).ToList();
        }
    }
}