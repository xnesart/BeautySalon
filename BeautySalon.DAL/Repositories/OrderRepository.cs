using System.Data;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BeautySalon.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    //не пашет
    // public List<GetMastersOrdersByIdDTO> GetMastersOrdersById(int id)
    // {
    //     using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
    //     {
    //         var parameters = new { Id = id };
    //         return connection.Query<GetMastersOrdersByIdDTO,UsersDTO,IntеrvalsDTO,ServicesDTO,UsersDTO,GetMastersOrdersByIdDTO>(Procedures.GetMastersOrdersById,
    //                 (orders,master,intervals,services,clients)=>
    //                 {
    //                     if (orders.Services == null)
    //                     {
    //                         orders.Services = new List<ServicesDTO>();
    //                     }
    //
    //                     if (orders.Master == null)
    //                     {
    //                         orders.Master = new List<UsersDTO>();
    //                     }
    //
    //                     if (orders.Client == null)
    //                     {
    //                         orders.Client = new List<UsersDTO>();
    //                     }
    //
    //                     if (orders.Intervals == null)
    //                     {
    //                         orders.Intervals = new List<IntеrvalsDTO>();
    //                     }
    //                 
    //                     orders.Master.Add(master);
    //                     orders.Intervals.Add(intervals);
    //                     orders.Services.Add(services);
    //                     orders.Client.Add(clients);
    //                     return orders;
    //                 },parameters,splitOn:"Id,MasterId,StartIntervalId,ServiceId,ClientId")
    //             .ToList();
    //     }
    // }

    public List<GetOrdersByMasterId> GetOrdersByMasterId(int id)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { Id = id };
            return connection.Query<UsersDTO,GetOrdersByMasterId,ServicesDTO,UsersDTO,GetOrdersByMasterId>(Procedures.GetOrdersByMasterId,
                    (master,order,service,client)=>
                    {
                        order.Master = master;
                        order.Services = service;
                        order.Client = client;
                        return order;
                    },parameters,splitOn:"Id")
                .ToList();
        } 
    }

    public List<OrdersDTO> RemoveOrderForClientByOrderId(int orderId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new { OrderId = orderId };
            return connection.Query<OrdersDTO>(Procedures.RemoveOrderForClientByOrderId, parameters).ToList();
        }
    }

    public List<GetAllOrdersOnTodayForMastersDTO> GetAllOrdersOnTodayForMasters()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllOrdersOnTodayForMastersDTO,UsersDTO,ServicesDTO,IntеrvalsDTO,UsersDTO, GetAllOrdersOnTodayForMastersDTO>(Procedures.GetAllOrdersOnTodayForMasters,
                    (order,master,service, intervals,client)=>
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
                    },splitOn:"Id,Title,Title,Name")
                .ToList();
        } 
    }
}