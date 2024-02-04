using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.DAL.Repositories;

public class UserRepository : IUserRepository
{
    public List<UsersDTO> AddUserByChatId(int chatId, string userName, string name, string phone, string mail,
        int roleId, decimal salary, int isBlocked, int isDeleted)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                ChatId = chatId,
                UserName = userName,
                Name = name,
                Phone = phone,
                Mail = mail,
                RoleID = roleId,
                Salary = salary,
                IsBlocked = isBlocked,
                IsDeleted = isDeleted
            };
            return connection.Query<UsersDTO>(Procedures.AddUserByChatId, parameters).ToList();
        }
    }

    public List<UsersDTO> GetAllEmployees()
    {
        throw new NotImplementedException();
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

    public List<UsersDTO> GetMasterByNameAndId(string name, int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Name = name,
                Id = id
            };
            return connection.Query<UsersDTO>(Procedures.GetMasterByNameAndId, parameters).ToList();
        }
    }

    public List<UsersDTO> GetMasterByNameAndPhone(string name, string phone)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Name = name,
                Phone = phone
            };
            return connection.Query<UsersDTO>(Procedures.GetMasterByNameAndPhone, parameters).ToList();
        }
    }

    public List<UsersDTO> GetAllWorkersByRoleId()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<UsersDTO>(Procedures.GetAllWorkersByRoleId).ToList();
        }
    }

    public List<GetAllWorkersWithContactsByUserIdDTO> GetAllWorkersWithContactsByUserId()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllWorkersWithContactsByUserIdDTO, RolesDTO, GetAllWorkersWithContactsByUserIdDTO>(Procedures.GetAllWorkersWithContactsByUserId,
                (users, roles) =>
                {
                    if (users.Roles == null)
                    {
                        users.Roles = new List<RolesDTO>();
                    }
                    users.Roles.Add(roles);
                    return users;
                }, splitOn: "Id,Worker").ToList();
        }
    }

    public void AddWorkerByRoleId(int role, string name, string phone, string mail)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                WorkerRole = role,
                WorkerName = name,
                WorkerPhone = phone,
                WorkerMail = mail
            };
            connection.Query<UsersDTO>(Procedures.AddWorkerByRoleId, parameters);
        }
    }

    public void RemoveUserById(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                Id = id
            };
            connection.Query<UsersDTO>(Procedures.RemoveUserById, parameters);
        }
    }

    public void AddMasterToShift(int masterId, int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                MasterId = masterId,
                ShiftId = shiftId
            };
            connection.Query<UsersDTO>(Procedures.AddMasterToShift, parameters);
        }
    }    
    
    public void RemoveMasterFromShift(int masterId, int shiftId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                MasterId = masterId,
                ShiftId = shiftId
            };
            connection.Query<UsersDTO>(Procedures.RemoveMasterFromShift, parameters);
        }
    }
}