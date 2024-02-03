using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BeautySalon.DAL.Repositories;

public class OrderRepository: IOrderRepository
{
    public List<OrdersDTO> GetAllOrdersForClient()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new {Id = 4};
            return connection.Query<OrdersDTO>(Procedures.GetAllWorkersByRoleId, parameters).ToList();
        }
    }
}