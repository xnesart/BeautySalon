using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.Console;

using System;

class Program
{
    static void Main(string[] args)
    {
        IOrderRepository orderRepository = new OrderRepository();
        orderRepository.RemoveOrderForClientByOrderId(1);

        Concole.WriteLine(); }
}