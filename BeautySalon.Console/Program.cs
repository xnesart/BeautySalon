using BeautySalon.BLL;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using BeautySalon.BLL.Clents;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.OrdersForClientById;
using BeautySalon.DAL.DTO;
using System;
using BeautySalon.BLL.AllShiftsWithFreeIntervalsOnCurrentServiceModel;
using BeautySalon.BLL.RemoveOrderForClientByOrderIInputModel;

class Program
{
    static void Main(string[] args)
    {

        //OrderClient orderClient = new OrderClient();

        //List<OrdersForClientByIdOutputModel> ordersForClients = orderClient.GetOrdersForClientById(1);

        //Console.WriteLine("до");

        //ordersForClients.ForEach(ordersForClients =>
        //{
        //    Console.Write(ordersForClients.Master.Id + " ");
        //    Console.Write(ordersForClients.Order.Id + " ");
        //    Console.Write(ordersForClients.Order.Id + " ");

        //    //Console.Write(ordersForClients.ClientId + "ClientName ");
        //    //Console.Write(ordersForClients.ClientName + "MasterId ");
        //    //Console.Write(ordersForClients.MasterId + "MasterName ");
        //    //Console.Write(ordersForClients.MasterName + "IntervalsId ");
        //    //Console.Write(ordersForClients.IntervalsId + "IntervalTitle ");
        //    //Console.Write(ordersForClients.IntervalTitle + "ServicesId ");
        //    //Console.Write(ordersForClients.ServicesId + "ServicesTitle ");
        //    //Console.Write(ordersForClients.ServicesTitle + "ServicesPrice ");
        //    //Console.Write(ordersForClients.ServicesPrice + " ");

        //    Console.WriteLine();
        //    Console.WriteLine();


            //ShiftsClient shiftsClient = new ShiftsClient();

            //List<ShiftsWithFreeIntervalsOnCurrentServiceOutputModel> shifts = shiftsClient.GetAllShiftsWithFreeIntervalsOnCurrentService(1);

            //Console.WriteLine("до");

            //shifts.ForEach(shiftsWithFreeIntervalsOnCurrentService =>
            //{
              

            //    Console.Write(shiftsWithFreeIntervalsOnCurrentService.Shift.Id + " ");
            //    Console.Write(shiftsWithFreeIntervalsOnCurrentService.Shift.Title + " ");
            //    Console.Write(shiftsWithFreeIntervalsOnCurrentService.Shift.StartTime + " ");
            //    Console.Write(shiftsWithFreeIntervalsOnCurrentService.Shift.EndTime + " ");
            //    Console.WriteLine();
            //    Console.WriteLine("----------------------------------------------------------");

            //});


    }
}
        
        
