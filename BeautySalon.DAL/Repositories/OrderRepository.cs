using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BeautySalon.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { Id = id };
            return connection.Query<UsersDTO, GetOrdersByMasterId, ServicesDTO, UsersDTO, GetOrdersByMasterId>(Procedures.GetOrdersByMasterId,
                    (master, order, service, client) =>
                    {
                        order.Master = master;
                        order.Services = service;
                        order.Client = client;
                        return order;
                    }, parameters, splitOn: "Id")
                .ToList();
        }
    }

    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllOrdersOnTodayForMastersDTO, UsersDTO, ServicesDTO, IntеrvalsDTO, UsersDTO, GetAllOrdersOnTodayForMastersDTO>(Procedures.GetAllOrdersOnTodayForMasters,
                    (order, master, service, intervals, client) =>
                    {
                        if (order.Master == null)
                        {
                            order.Master = new List<UsersDTO>();
                        }
                        order.Master.Add(master);
                        if (order.Services == null)
                        {
                            order.Services = new List<ServicesDTO>();
                        }
                        order.Services.Add(service);
                        if (order.Intervals == null)
                        {
                            order.Intervals = new List<IntеrvalsDTO>();
                        }
                        order.Intervals.Add(intervals);
                        if (order.Client == null)
                        {
                            order.Client = new List<UsersDTO>();
                        }
                        order.Client.Add(client);
                        return order;
                    }, splitOn: "Id,Title,Title,Name")
                .ToList();
        }
    }
    public List<OrdersByClientIdDTO> GetOrderByClientId(int clientid)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameter = new
            {
                Id = clientid,
            };

            return connection.Query<OrdersDTO,UsersDTO, UsersDTO,IntеrvalsDTO,ServicesDTO, OrdersByClientIdDTO>
                 (
                     Procedures.GetOrdersByClientId2,
                     (order,client, master,interval,service) =>
                     {
                         OrdersByClientIdDTO orderByClient = new OrdersByClientIdDTO();

                         orderByClient.Order = new OrdersDTO();
                         orderByClient.Order.Id = order.Id;
                         orderByClient.Order.Date = order.Date;
                         orderByClient.Order.StartIntervalId = order.StartIntervalId;

                         orderByClient.Client = new UsersDTO();
                         orderByClient.Client.Id = client.Id;
                         orderByClient.Client.Name = client.Name;

                         orderByClient.Master = new UsersDTO();
                         orderByClient.Master.Id = master.Id;
                         orderByClient.Master.Name = master.Name;

                         orderByClient.Interval = new IntеrvalsDTO();
                         orderByClient.Interval.Id = interval.Id;
                         orderByClient.Interval.Title = interval.Title;

                         orderByClient.Service = new ServicesDTO();
                         orderByClient.Service.Id = service.Id;
                         orderByClient.Service.Title = service.Title;
                         orderByClient.Service.Duration = service.Duration;
                         orderByClient.Service.Price = service.Price;

                         return orderByClient;
                     },
                     parameter,
                     splitOn: "Id,Id,Id,Id,Id"
                 ).ToList();
        }
    }

    public void UpdateOrderTimeForClientById(int orderId, int clientId, int masterId, int intervalId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
            OrderId = orderId,
            ClientId = clientId,
            MasterId = masterId,
            IntervalId = intervalId
            };
            connection.Query(Procedures.UpdateOrderTimeForClientById, parameters).ToList();
        }
    }
    public void RemoveOrderForClientByOrderId(int orderId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
            OrderId = orderId
            };
         connection.Query<OrdersDTO>(Procedures.RemoveOrderForClientByOrderId, parameters);
        }
    }
    public void CreateNewOrder(int clientId, int masterId, DateTime date, int serviceId, int intervalId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
            ClientId = clientId,
            MasterId = masterId,
            Date = date,
            ServiceId = serviceId,
            IntervalId = intervalId
            };

            connection.Query<OrdersDTO>(Procedures.CreateNewOrder, parameters);
        }
    }
}
   