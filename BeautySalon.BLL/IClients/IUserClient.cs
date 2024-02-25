using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.IClient
{
    public interface IUserClient
    {
        public List<AllWorkersByRoleIdOutputModel> GetAllWorkersByRoleId();
        public List<AllWorkersByRoleIdOutputModel> GetAllWorkersByRoleIdExcludeDeleted();
        public List<ClientByNameAndIdOutputModel> GetClientByNameAndId(string name, int id);
        public void AddUserByChatId(AddUserByChatIdInputModel model);
        public List<ClientByNameAndPhoneOutputModel> GetClientByNameAndPhone(string name, string phone);
        public List<MasterByNameAndIdOutputModel> GetMasterByNameAndId(string name, int id);
        public UserIsDeletedOutputModel RemoveUserById(UserIdInputModel model);
        public void ChangeMasterInShift(int masterId, int shiftId);
        public List<CheckAndAddUserOutputModel> CheckAndAddUser(int chatId);
        public List<MasterByNameAndPhoneOutputModel> GetMasterByNameAndPhone(string name, string phone);
        public List<UserByChatIdOutputModel> GetUserByChatId(int chatId);
        public int GetFreeMasterByIntervalIdNew(int intervalId);
        public string? GetWorkerNameByPassword(string password);
        public void ChangeChatIdAndUserNameByPassword(string password, int chatId, string userName);
        public void RemoveMasterFromShift(int masterId, int shiftId);
    }
}
