using System.Collections.Generic;
using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IUserRepository
{
    public List<GetAllChatIdDTO> GetAllChatId();
    // public List<UsersDTO> AddUserByChatId(int chatId,string userName ,string name, string phone, string mail, int roleId, decimal salary,int isBlocked, int isDeleted);
    public List<UsersDTO> AddUserByChatId(UsersDTO usersDto);
    public List<UsersDTO> GetClientByNameAndId(string name, int id);
    public List<UsersDTO> GetClientByNameAndPhone(string name, string phone);
    public List<UsersDTO> GetMasterByNameAndId(string name, int id);
    public List<UsersDTO> GetMasterByNameAndPhone(string name, string phone);
    public List<UsersDTO> GetAllWorkersByRoleId();
    public List<GetAllWorkersWithContactsByUserIdDTO> GetAllWorkersWithContactsByUserId();
    // public void AddWorkerByRoleId(int role, string name, string phone, string mail);
    public void AddWorkerByRoleId(AddWorkerByRoleIdDTO addWorkerByRoleIdDTO);
    public UsersDTO RemoveUserById(int id);
    public void ChangeMasterInShift(int masterId, int shiftId);
    public void RemoveMasterFromShift(int masterId, int shiftId);
    public List<GetMastersShiftsById> GetMastersShiftsById(int id);
    public List<GetFreeMastersAndIntervalsOnTodayDTO> GetFreeMastersAndIntervalsOnToday();
    public List<UsersDTO> CheckAndAddUser(int chatId);
    public List<UsersDTO> GetUserByChatId(int chatId);
}