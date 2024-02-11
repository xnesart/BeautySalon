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
        IServicesRepository rep= new ServicesRepository();
        List<AllFreeIntervalsOnCurrentServiceDTO> result = rep.GetAllFreeIntervalsOnCurrentService(1);
        result.ForEach((el) => Console.WriteLine(el.Services.Title));


    }
}