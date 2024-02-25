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
            return connection.Query<UsersDTO, ServicesDTO, IntеrvalsDTO, UsersDTO, OrdersDTO, GetAllOrdersOnTodayForMasterDTO>(Procedures.GetAllOrdersOnTodayForMasters,
                    (master, service, intervals, client, orderDTO) =>
                    {
                        GetAllOrdersOnTodayForMasterDTO order = new GetAllOrdersOnTodayForMasterDTO();

                        order.Master = new UsersDTO();
                        order.Master.Id = master.Id;
                        order.Master.Salary = master.Salary;
                        order.Master.UserName = master.UserName;
                        order.Master.Name = master.Name;
                        order.Master.ChatId = master.ChatId;
                        order.Master.RoleId = master.RoleId;

                        order.Services = new ServicesDTO();
                        order.Services.Title = service.Title;
                        order.Services.Price = service.Price;
                        order.Services.Duration = service.Duration;
                        order.Services.TypeId = service.TypeId;

                        order.Intervals = new IntеrvalsDTO();
                        order.Intervals.Id = intervals.Id;
                        order.Intervals.IsBusy = intervals.IsBusy;
                        order.Intervals.Shifts = intervals.Shifts;
                        order.Intervals.ShiftId = intervals.ShiftId;
                        order.Intervals.StartTime = intervals.StartTime;
                        order.Intervals.Title = intervals.Title;

                        order.Client = new UsersDTO();
                        order.Client.ChatId = client.ChatId;
                        order.Client.Id= client.Id;
                        order.Client.RoleId = client.RoleId;
                        order.Client.Name = client.Name;
                        order.Client.Phone = client.Phone;
                        order.Client.UserName = client.UserName;

                        order.Orders = new OrdersDTO();
                        order.Orders.ClientId = orderDTO.ClientId;
                        order.Orders.IntervalId=orderDTO.IntervalId;
                        order.Orders.ServiceId = orderDTO.ServiceId;
                        order.Orders.MasterId = orderDTO.MasterId;
                        order.Orders.Id = orderDTO.Id;
                        order.Orders.Date = orderDTO.Date;

                        return order;
                    }, splitOn: "Id,Id,Title,Title,Name")
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

    public void UpdateOrderTimeByOrderId (OrdersDTO orders)
    {
        using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
        {
            var parameters = new
            {
            OrderId = orders.Id,
            IntervalId = orders.IntervalId
            };
            connection.Query(Procedures.UpdateOrderTimeByOrderId, parameters);
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
   