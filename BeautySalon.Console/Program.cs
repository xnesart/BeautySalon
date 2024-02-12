using BeautySalon.BLL;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using BeautySalon.BLL.Clents;
using BeautySalon.BLL.OrderModels.InputModels;
using BeautySalon.DAL.DTO;
using System;

class Program
{
    static void Main(string[] args)
    {
        IOrderRepository repo = new OrderRepository();
        List<OrdersByClientIdDTO> orders = repo.GetOrderByClientId(4);

        // до
        Console.WriteLine("До");

        orders.ForEach(order =>
        {
            Console.Write(order.Order.Id + " ");
            Console.Write(order.Order.ServiceId + " ");
            Console.Write(order.Service.Title + " ");
            Console.Write(order.Master.Name + " ");
            Console.Write(order.Client.Name + " ");
            Console.Write(order.StartIntervalId + " ");
            Console.Write(order.Interval + " ");
            Console.Write(order.Date + " ");

            Console.WriteLine();
            Console.WriteLine();
        });

        OrderClient client = new OrderClient();
        client.CreateNewOrder(new NewOrderInputModel()
        {
            ClientId = 4,
            Date = DateTime.Now,
            MasterId = 1,
            ServiceId = 1,
            StartIntervalId = 1
        });

        // после
        Console.WriteLine();
        Console.WriteLine("После");

        orders = repo.GetOrderByClientId(4);

        orders.ForEach(order =>
        {
            Console.Write(order.Order.Id + " ");
            Console.Write(order.Order.ServiceId + " ");
            Console.Write(order.Service.Title + " ");
            Console.Write(order.Master.Name + " ");
            Console.Write(order.Client.Name + " ");
            Console.Write(order.StartIntervalId + " ");
            Console.Write(order.Interval.StartTime + " ");
            Console.Write(order.Date + " ");

            Console.WriteLine();
            Console.WriteLine();
        });
    }
}