using BeautySalon.BLL;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using BeautySalon.BLL.Clents;
using BeautySalon.BLL.CreateGetOrdersForClientByIdOutputModel;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.OrderModels.InputModels;
using BeautySalon.DAL.DTO;
using System;

class Program
{
    static void Main(string[] args)
    {
        OrderClient orderClient = new OrderClient();

        List<OrdersForClientByIdOutputModel> ordersForClients = orderClient.GetOrdersForClientById(1);

        Console.WriteLine("до");

        ordersForClients.ForEach(ordersForClients =>
        {
            Console.Write(ordersForClients.OdrerId + "OdrerDate ");
            Console.Write(ordersForClients.OdrerDate + "OdrerStartIntervalId ");
            Console.Write(ordersForClients.OdrerStartIntervalId + "ClientId ");
            Console.Write(ordersForClients.ClientId + "ClientName ");
            Console.Write(ordersForClients.ClientName + "MasterId ");
            Console.Write(ordersForClients.MasterId + "MasterName ");
            Console.Write(ordersForClients.MasterName + "IntervalsId ");
            Console.Write(ordersForClients.IntervalsId + "IntervalTitle ");
            Console.Write(ordersForClients.IntervalTitle + "ServicesId ");
            Console.Write(ordersForClients.ServicesId + "ServicesTitle ");
            Console.Write(ordersForClients.ServicesTitle + "ServicesPrice ");
            Console.Write(ordersForClients.ServicesPrice + " ");

            Console.WriteLine();
            Console.WriteLine();
        });
        
        
        

    }

}