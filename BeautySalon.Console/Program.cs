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

        IIntervalsRepository repositoryInt = new IntervalsRepository();
        List<GetAllFreeIntervalsInCurrentShiftOnCurrentServiceDTO> intervals = repositoryInt.GetAllFreeIntervalsInCurrentShiftOnCurrentService(1, 1);
        intervals.ForEach(intervals => { Console.WriteLine(intervals.Interval.StartTime); });
    }
}




    
