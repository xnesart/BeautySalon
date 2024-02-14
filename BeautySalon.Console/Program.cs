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
        //    IShiftsRepository repository = new ShiftsRepository();
        //    List<GetAllShiftsWithFreeIntervalsOnCurrentServiceDTO> shifts = repository.GetAllShiftsWithFreeIntervalsOnCurrentService(1);
        //    shifts.ForEach(shift => { Console.WriteLine(shift.Shifts.Id); });

        // IIntervalsRepository repositoryInt = new IntervalsRepository();
        // List<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO> intervals = repositoryInt.GetAllFreeIntervalsInCurrentShiftOnCurrentService(1, 1);
        // intervals.ForEach(intervals => { Console.WriteLine(intervals.Interval.StartTime); });

        // IOrderRepository orderRepository = new OrderRepository();
        // orderRepository.RemoveOrderForClientByOrderId(1);

        #region NotWorks

        // Не пашет

        #endregion

        #region Works

        ////Работает
        //IUserRepository userRepository4 = new UserRepository();
        //userRepository4.AddUserByChatId(32423, "Janet342", "Жанна Дарк", "8999324556", "jannet@mail.ru", 3, 0, 0, 0);

        ////Работает
        //IUserRepository userRepository2 = new UserRepository();
        //var userRepositories2 = userRepository2.GetClientByNameAndId("Оксана Дмитриевна Кек", 4);
        //foreach (var user in userRepositories2)
        //{
        //    Console.WriteLine($"{user.ClientId} {user.Client}");
        //}

        ////Работает
        //IUserRepository userRepository3 = new UserRepository();
        //var userRepositories3 = userRepository3.GetClientByNameAndPhone("Оксана Дмитриевна Кек", "877566588690");
        //foreach (var user in userRepositories3)
        //{
        //    Console.WriteLine($"{user.Name} {user.Phone}");
        //}

        ////Работает
        //IUserRepository userRepository5 = new UserRepository();
        //var userRepositories5 = userRepository5.GetMasterByNameAndId("Анна Петровна Брек", 2);
        //foreach (var user in userRepositories5)
        //{
        //    Console.WriteLine($"{user.Master} {user.MasterId}");
        //}

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //var usersRepositories = userRepository.GetMasterByNameAndPhone("Анна Петровна Брек", "8923467127");
        //foreach (var user in usersRepositories)
        //{
        //    Console.WriteLine($"{user.Master}, {user.MasterPhone}");
        //}

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //var userRepositories = userRepository.GetAllWorkersWithContactsByUserId();
        //foreach (var user in userRepositories)

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

        ////Работает
        // IntervalsClient intervalsClient = new IntervalsClient();
        // var q = intervalsClient.GetAllFreeIntervalsOnCurrentService(1, 2);
        // Console.ReadLine();

        ////Работает
        // IntervalsClient intervalsClient = new IntervalsClient();
        // var q = intervalsClient.GetAllIntervals("2024-02-14");
        // Console.ReadLine();

        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetAllWorkersByRoleId();
        // Console.ReadLine();  

        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetClientByNameAndId("Анна Петровна Брек",2);
        // Console.ReadLine();

        //Работает
        // UserClient client = new UserClient();
        // AddUserByChatIdInputModel model = new AddUserByChatIdInputModel
        // {
        //     ChatId = 1234323,
        //     UserName = "432KKK",
        //     Name = "Лера Павловна ",
        //     Phone = "854356654645",
        //     Mail = "ffdggfddg@fdgfgfd",
        //     RoleId = 3,
        //     Salary = 0,
        //     IsBlocked = 0,
        //     IsDeleted = 0
        // };
        // client.AddUserByChatId(model);

        //Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetClientByNameAndPhone("Кристина Валерьевна Заливняк","642894209");
        // Console.ReadLine();

        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetMasterByNameAndId("Анна Петровна Брек",2);
        // Console.ReadLine();
        //

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


        // //Работает
        // UserClient userClient = new UserClient();
        // WorkerByRoleIdInputModel model = new WorkerByRoleIdInputModel
        // {
        //     RoleId = 2,
        //     Name = "Иваска Петровна Шнюк",
        //     Mail = "23уцкапв@gmail.com",
        //     Phone = "232424356"
        // };
        //
        // userClient.AddWorkerByRoleId(model);
        // Console.ReadLine();

        //Работает
        // UserClient userClient = new UserClient();
        // var res = userClient.GetAllChatId();
        // Console.WriteLine();

        #endregion
    }
}