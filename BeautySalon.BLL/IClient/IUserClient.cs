using BeautySalon.BLL.Models;
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


    }
}
