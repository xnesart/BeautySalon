using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    public List<GetAllOrdersOnTodayForMasterDTO> GetAllOrdersOnTodayForMaster()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query< UsersDTO, ServicesDTO, IntеrvalsDTO, UsersDTO,OrdersDTO, GetAllOrdersOnTodayForMasterDTO>(Procedures.GetAllOrdersOnTodayForMasters,
                    ( master, service, intervals, client,order) =>
                    {
                        GetAllOrdersOnTodayForMasterDTO getAllOrdersOn = new GetAllOrdersOnTodayForMasterDTO();


                        getAllOrdersOn.Master = new UsersDTO();
                        getAllOrdersOn.Master.Id = master.Id;
                        getAllOrdersOn.Master.Salary = master.Salary;
                        getAllOrdersOn.Master.UserName = master.UserName;
                        getAllOrdersOn.Master.Name = master.Name;
                        getAllOrdersOn.Master.ChatId = master.ChatId;
                        getAllOrdersOn.Master.RoleId = master.RoleId;

                        getAllOrdersOn.Services = new ServicesDTO();
                        getAllOrdersOn.Services.Title = service.Title;
                        getAllOrdersOn.Services.Price = service.Price;
                        getAllOrdersOn.Services.Duration = service.Duration;
                        getAllOrdersOn.Services.TypeId = service.TypeId;

                        getAllOrdersOn.Intervals = new IntеrvalsDTO();
                        getAllOrdersOn.Intervals.Id = intervals.Id;
                        getAllOrdersOn.Intervals.IsBusy = intervals.IsBusy;
                        getAllOrdersOn.Intervals.Shifts = intervals.Shifts;
                        getAllOrdersOn.Intervals.ShiftId = intervals.ShiftId;
                        getAllOrdersOn.Intervals.StartTime = intervals.StartTime;
                        getAllOrdersOn.Intervals.Title = intervals.Title;

                        getAllOrdersOn.Client = new UsersDTO();
                        getAllOrdersOn.Client.ChatId = client.ChatId;
                        getAllOrdersOn.Client.Id= client.Id;
                        getAllOrdersOn.Client.RoleId = client.RoleId;
                        getAllOrdersOn.Client.Name = client.Name;
                        getAllOrdersOn.Client.Phone = client.Phone;
                        getAllOrdersOn.Client.UserName = client.UserName;

                        getAllOrdersOn.Orders = new OrdersDTO();
                        getAllOrdersOn.Orders.ClientId = order.ClientId;
                        getAllOrdersOn.Orders.IntervalId=order.IntervalId;
                        getAllOrdersOn.Orders.ServiceId = order.ServiceId;
                        getAllOrdersOn.Orders.MasterId = order.MasterId;
                        getAllOrdersOn.Orders.Id = order.Id;
                        getAllOrdersOn.Orders.Date = order.Date;

                        return getAllOrdersOn;

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
                         orderByClient.Order.IntervalId = order.IntervalId;

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

    public void UpdateOrderTimeForClientById(OrdersDTO orders)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
            OrderId = orders.Id,
            ClientId = orders.ClientId,
            MasterId = orders.MasterId,
            IntervalId = orders.IntervalId
            };
            connection.Query(Procedures.UpdateOrderTimeForClientById, parameters).ToList();
        }
    }
    public void RemoveOrderForClientByOrderId(OrdersDTO order)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameter = new
            {
                OrderId = order.Id,
            };
         connection.Query<OrdersDTO>(Procedures.RemoveOrderForClientByOrderId, parameter);
        }
    }
    public void CreateNewOrder(OrdersDTO newOrder)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                ClientId = newOrder.ClientId,
                MasterId = newOrder.MasterId,
                Date = newOrder.Date,
                ServiceId = newOrder.ServiceId,
                IntervalId = newOrder.IntervalId
            };

            connection.Query<OrdersDTO>(Procedures.CreateNewOrder, parameters);
        }
    }
    
    public List<GetAllOrdersOnTodayDTO> GetAllOrdersOnToday()
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            return connection.Query<GetAllOrdersOnTodayDTO>(Procedures.GetAllOrdersOnToday).ToList();
        }
    }

    public void AddClientToFreeMaster(int clientId, int serviceId, int shiftId, int intervalId)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
                ClientId = clientId,
                ServiceId = serviceId,
                ShiftId = shiftId,
                IntervalId = intervalId
            };
            connection.Query(Procedures.AddClientToFreeMaster, parameters);
        }
    }
}
   