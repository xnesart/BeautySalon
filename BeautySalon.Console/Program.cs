using BeautySalon.BLL;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using BeautySalon.DAL.DTO;
using System;

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
        //{
        //    Console.WriteLine($"{user.Name}");
        //}

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //userRepository.AddWorkerByRoleId(2, "Кирилл Модестович Мусоргский", "834734269540", "kbslrbkl@sdfsdf");
        //Console.ReadLine();

        //IUserRepository userRepository = new UserRepository();
        //userRepository.AddWorkerByRoleId(2, "Александр Максимович Климов", "85459004345", "xghj@hzf");
        //Console.ReadLine();

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //userRepository.RemoveUserById(5);
        //Console.ReadLine();

        ////Работает
        //IShiftsRepository shiftRepository = new ShiftsRepository();
        //var shiftsRepositories = shiftRepository.GetAllShiftsOnToday();
        //foreach (var shift in shiftsRepositories)
        //{
        //    Console.WriteLine();
        //}

        ////Работает
        //IShiftsRepository shiftRepository = new ShiftsRepository();
        //var shiftsRepositories = shiftRepository.GetAllShiftsAndEmployeesOnToday();
        //foreach (var shift in shiftsRepositories)
        //{
        //    Console.WriteLine($"{shift.Name}");
        //    foreach (var value in shift.Shifts)
        //    {
        //        Console.WriteLine($"{value.Id}, {value.Title}, {value.StartTime}, {value.EndTime}");
        //    }
        //}

        ////Работает
        // IShiftsRepository shiftRepository = new ShiftsRepository();
        // var shiftsRepositories = shiftRepository.GetAllShiftsWithFreeIntervals();
        // foreach (var shift in shiftsRepositories)
        // {
        //     Console.WriteLine($"{shift.Id}, {shift.Title}, {shift.StartTime}");
        //     foreach (var value in shift.Intervals)
        //     {
        //         Console.WriteLine($"{value.IsBusy}");
        //     }
        // }

        ////Работает, но не добавляет, а перезаписывает
        // IUserRepository userRepository = new UserRepository();
        // userRepository.AddMasterToShift(7, 3);
        // IOrderRepository orderRepository = new OrderRepository();
        // var repositories = orderRepository.GetAllOrdersForClient();
        // foreach (var repository in repositories)
        // {
        //     Console.WriteLine($"{repository.Id} {repository.Date} {repository.ClientId} {repository.MasterId}");
        // }
        //

        ////Работает
        // IIntervalsRepository intervalsRepository = new IntervalsRepository();
        // var intervalsRepositories = intervalsRepository.GetAllShiftsWithFreeIntervalsOnCurrentService();
        // foreach (var user in userRepositories)
        // {
        //     Console.WriteLine($"{user.Id} {user.Name} {user.Phone} {user.Mail} {user.Roles}");
        // }
        // Console.WriteLine();

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //userRepository.RemoveMasterFromShift(2, 1);
        //Console.ReadLine();

        ////Работает
        //IIntervalsRepository intervalsRepository = new IntervalsRepository();
        //var intervalsRepositories = intervalsRepository.GetAllShiftsWithFreeIntervalsOnCurrentService(4);
        //foreach (var interval in intervalsRepositories)
        //{
        //    Console.WriteLine($"");
        //}

        ////Работает
        // IUserRepository userRepository = new UserRepository();
        // var userRepositories = userRepository.GetAllWorkersByRoleId();
        // foreach (var user in userRepositories)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        // IIntervalsRepository intervalsRepository = new IntervalsRepository();
        // var  intervals = intervalsRepository.GetAllIntervalsByShiftId(1);
        // foreach (var interval in intervals)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        // IIntervalsRepository intervalsRepository = new IntervalsRepository();
        // var  intervals = intervalsRepository.GetAllFreeIntervalsByShiftId(1);
        // foreach (var interval in intervals)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        // IServicesRepository servicesRepository = new ServicesRepository();
        // var services = servicesRepository.GetAllServicesByIdFromCurrentType(1);
        // foreach (var service in services)
        // {
        //     Console.WriteLine();
        // }

        ////Работает. Разбирали на занятии с Максом.
        // IOrderRepository orderRepository = new OrderRepository();
        // var orders = orderRepository.GetOrdersByMasterId(2);
        // foreach (var order in orders)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        // ITypesRepository typesRepository = new TypesRepository();
        // var types = typesRepository.GetAllServiceTypes();
        // foreach (var type in types)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        // IServicesRepository servicesRepository = new ServicesRepository();
        // servicesRepository.UpdateServiceTitle(1, "Подравнять кончики");

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //var users = userRepository.GetMastersShiftsById(2);
        //foreach (var user in users)
        //{
        //    Console.WriteLine();
        //}

        ////Работает
        // IOrderRepository orderRepository = new OrderRepository();
        // var orders = orderRepository.GetAllOrdersOnTodayForMasters();
        // foreach (var user in orders)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        //IIntervalsRepository intervalsRepository = new IntervalsRepository();
        //var intervals = intervalsRepository.GetAllIntervals("2024 - 02 - 02");
        //foreach (var interval in intervals)
        //{
        //    Console.WriteLine();
        //}

        ////Работает
        //IServicesRepository servicesRepository = new ServicesRepository();
        //var services = servicesRepository.GetAllServices();
        //foreach (var service in services)
        //{
        //    Console.WriteLine();
        //}

        // IUserRepository userRepository = new UserRepository();
        // var users = userRepository.GetClientByNameAndPhone("Кристина Валерьевна Заливняк","642894209");
        // foreach (var user in users)
        // {
        //     Console.WriteLine();
        // }
        ////Работает
        //IServicesRepository servicesRepository = new ServicesRepository();
        //servicesRepository.AddServiceById("Бритьё налысо", 1, "00:45", 500);

        ////Работает
        // IServicesRepository servicesRepository = new ServicesRepository();
        // servicesRepository.UpdateServicePrice(1, 500);

        ////Работает
        // IServicesRepository servicesRepository = new ServicesRepository();
        // servicesRepository.UpdateServiceDuration(6, "00:30");

        ////Работает
        // IServicesRepository servicesRepository = new ServicesRepository();
        // servicesRepository.RemoveServiceById(6);
        // Console.ReadLine();

        ////Работает
        // IOrderRepository orderRepository = new OrderRepository();
        // var orders = orderRepository.GetAllOrdersOnToday();
        // foreach (var user in orders)
        // {
        //     Console.WriteLine();
        // }

        ////Работает
        // IOrderRepository orderRepository = new OrderRepository();
        // orderRepository.AddClientToFreeMaster(2, 1, 2, 30);

        #endregion

        #region Bll

        ////Работает
        // IntervalsClient intervalsClient = new IntervalsClient();
        // var q = intervalsClient.GetAllFreeIntervalsInCurrentShiftOnCurrentService(1, 2);
        // Console.ReadLine();

        ////Работает
        IntervalsClient intervalsClient = new IntervalsClient();
        var q = intervalsClient.GetAllIntervals("2024-02-12");
        Console.ReadLine();

        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetAllWorkersByRoleId();
        // Console.ReadLine();  
   
        // UserClient userClient = new UserClient();
        // var q = userClient.GetClientByNameAndId("Анна Петровна Брек",2);
        // Console.ReadLine();
        
        //Работает
        // UserClient client = new UserClient();
        // client.AddUserByChatId(1232,"rabbit","Петя Петров Витальевич","87474344334","jerr@mail.com",3,0,0,0);

        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetClientByNameAndPhone("Кристина Валерьевна Заливняк","642894209");
        // Console.ReadLine();
        
        ////Работает
        // UserClient userClient = new UserClient();
        // var q = userClient.GetMasterByNameAndId("Анна Петровна Брек",2);
        // Console.ReadLine();
        //
        
        // UserClient userClient = new UserClient();
        // var q = userClient.GetMasterByNameAndPhone("Анна Петровна Брек","8923467127");
        // Console.ReadLine();
        #endregion
    }
    
}
