using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using BeautySalon.DAL.DTO;
using System;

class Program
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
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

        ////public const string GetAllShiftsOnToday = "GetAllShiftsOnToday";

        ////Работает
        // IShiftsRepository shiftRepository = new ShiftsRepository();
        // var shiftsRepositories = shiftRepository.GetAllShiftsAndEmployees();
        // foreach (var shift in shiftsRepositories)
        // {
        //     Console.WriteLine($"{shift.Name}");
        //     foreach (var value in shift.Shifts)
        //     {
        //         Console.WriteLine($"{value.Id}, {value.Title}, {value.StartTime}, {value.EndTime}");
        //     }
        // }


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
        //     Console.WriteLine($"{user.Id} {user.Name} {user.Phone} {user.Mail} {user.Roles}");
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

        ////Hаботает
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
        // servicesRepository.UpdateServiceTitle(1, "Стрижка бензопилой");

        ////Работает
        //IUserRepository userRepository = new UserRepository();
        //var users = userRepository.GetMastersShiftsById(2);
        //foreach (var user in users)
        //{
        //    Console.WriteLine();
        //}

        ////Работает
        //IOrderRepository orderRepository = new OrderRepository();
        //var orders = orderRepository.GetAllOrdersOnTodayForMasters();
        //foreach (var user in orders)
        //{
        //    Console.WriteLine();
        //}

        ////Работает
        //IIntervalsRepository intervalsRepository = new IntervalsRepository();
        //var intervals = intervalsRepository.GetAllIntervals("2024 - 02 - 02");
        //foreach (var interval in intervals)
        //{
        //    Console.WriteLine();
        //}

        #endregion
=======
>>>>>>> main
    }
}