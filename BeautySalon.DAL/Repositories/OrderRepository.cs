using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BeautySalon.DAL.Repositories;

public class OrderRepository: IOrderRepository
{
    public List<OrdersDTO> RemoveOrderForClientByOrderId(int orderId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { OrderId = orderId };
            return connection.Query<OrdersDTO>(Procedures.RemoveOrderForClientByOrderId, parameters).ToList();
        }
    }
}