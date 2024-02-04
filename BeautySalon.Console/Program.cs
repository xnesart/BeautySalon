using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using System;

class Program
{
    static void Main(string[] args)
    {
        #region NotDone

        ////Недописана
        //IUserRepository userRepository = new UserRepository();
        //var userRepositories = userRepository.GetAllWorkersByRoleId();
        //foreach (var user in userRepositories)
        //{
        //    Console.WriteLine($"{user.Id} {user.Name} {user.Phone} {user.Mail} {user.Roles}");
        //}

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
        //    Console.WriteLine($"{user.ClientsId} {user.Client}");
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
        //IShiftsRepository shiftRepository = new ShiftsRepository();
        //var shiftsRepositories = shiftRepository.GetAllShiftsAndEmployees();
        //foreach (var shift in shiftsRepositories)
        //{
        //    Console.WriteLine($"{shift.Name}");
        //    foreach (var value in shift.Shifts)
        //    {
        //        Console.WriteLine($"{value.Id}, {value.Title}, {value.StartTime}, {value.EndTime}");
        //    }
        //}

        ////Работает, но не добавляет, а перезаписывает
        //IUserRepository userRepository = new UserRepository();
        //userRepository.AddMasterToShift(7, 3);
        //Console.ReadLine();

        //Работает
        IUserRepository userRepository = new UserRepository();
        userRepository.RemoveMasterFromShift(2, 1);
        Console.ReadLine();

        ////Работает
        //IIntervalsRepository intervalsRepository = new IntervalsRepository();
        //var intervalsRepositories = intervalsRepository.GetAllShiftsWithFreeIntervalsOnCurrentService(4);
        //foreach (var interval in intervalsRepositories)
        //{
        //    Console.WriteLine($"");
        //}

        #endregion
    }

    class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }
    }
}