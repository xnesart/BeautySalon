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
        public List<ClientByNameAndIdOutputModel> GetClientByNameAndId(string name, int id);
        public void AddUserByChatId(AddUserByChatIdInputModel model);
        public List<ClientByNameAndPhoneOutputModel> GetClientByNameAndPhone(string name, string phone);
        public List<MasterByNameAndIdOutputModel> GetMasterByNameAndId(string name, int id);
        public UserIsDeletedOutputModel RemoveUserById(UserIdInputModel model);
        public void ChangeMasterInShift(int masterId, int shiftId);
        // public List<CheckAndAddUserOutputModel> CheckAndAddUser(int chatId);
    }
}
