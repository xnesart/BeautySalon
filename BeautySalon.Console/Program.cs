using System.Data;
using BeautySalon.DAL;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.Console;
using System;

class Program
{
    static void Main(string[] args)
    {

        // IOrderRepository orderRepository = new OrderRepository();
        // var repositories = orderRepository.GetAllOrdersForClient();
        // foreach (var repository in repositories)
        // {
        //     Console.WriteLine($"{repository.Id} {repository.Date} {repository.ClientId} {repository.MasterId}");
        // }
        
        // IUserRepository userRepository = new UserRepository();
        // var userRepositories = userRepository.GetAllEmployees();
        // foreach (var user in userRepositories)
        // {
        //     Console.WriteLine($"{user.Id} {user.Name} {user.Phone} {user.Mail} {user.Roles}");
        // }
        
        
        // IUserRepository userRepository2 = new UserRepository();
        // var userRepositories2 = userRepository2.GetClientByNameAndId("Оксана Дмитриевна Кек", 4);
        // foreach (var user in userRepositories2)
        // {
        //     Console.WriteLine($"{user.ClientsId} {user.Client}");
        // }
        
        IUserRepository userRepository3 = new UserRepository();
        var userRepositories3 = userRepository3.GetClientByNameAndPhone("Оксана Дмитриевна Кек", "877566588690");
        foreach (var user in userRepositories3)
        {
            Console.WriteLine($"{user.Name} {user.Phone}");
        }
        
        // IIntervalsRepository intervalsRepository = new IntervalsRepository();
        // var intervalsRepositories = intervalsRepository.GetAllShiftsWithFreeIntervalsOnCurrentService();
        // foreach (var user in userRepositories)
        // {
        //     Console.WriteLine($"{user.Id} {user.Name} {user.Phone} {user.Mail} {user.Roles}");
        // }
        // Console.WriteLine();
        Console.ReadLine();
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