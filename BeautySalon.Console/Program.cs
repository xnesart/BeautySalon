using BeautySalon.BLL;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using BeautySalon.BLL.Clents;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.OrdersForClientById;
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
            Console.Write(ordersForClients.Master.Id +" ");
            Console.Write(ordersForClients.Order.Id +" ");
            Console.Write(ordersForClients.Order.Id + " ");

            //Console.Write(ordersForClients.ClientId + "ClientName ");
            //Console.Write(ordersForClients.ClientName + "MasterId ");
            //Console.Write(ordersForClients.MasterId + "MasterName ");
            //Console.Write(ordersForClients.MasterName + "IntervalsId ");
            //Console.Write(ordersForClients.IntervalsId + "IntervalTitle ");
            //Console.Write(ordersForClients.IntervalTitle + "ServicesId ");
            //Console.Write(ordersForClients.ServicesId + "ServicesTitle ");
            //Console.Write(ordersForClients.ServicesTitle + "ServicesPrice ");
            //Console.Write(ordersForClients.ServicesPrice + " ");

            Console.WriteLine();
            Console.WriteLine();
        });
        
        
<<<<<<< HEAD
        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetMasterByNameAndPhone("Анна Петровна Брек","8923467127");
        // Console.ReadLine();
        //
        // //Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetAllWorkersWithContactsByUserId();
        // Console.ReadLine();  
        
        
        // //Работает
        // ShiftsClient shiftsClient = new ShiftsClient();
        // var q = shiftsClient.GetAllShiftsOnToday();
        // Console.ReadLine();

        // //Работает
        // IntervalsClient intervalsClient = new IntervalsClient();
        // var q = intervalsClient.GetAllFreeIntervalsOnCurrentService(1,2);
        // Console.ReadLine();  
        #endregion
=======
        

>>>>>>> main
    }

}