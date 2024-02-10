using BeautySalon.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.IRepositories
{
    public interface IServicesRepository
    {
        //public List<ServicesDTO> GetServicesWithPriceAndDuratonByTypeId(int typeId);
        public List<GetAllServicesByIdFromCurrentTypeDTO> GetAllServicesByIdFromCurrentType(int id);
        public void UpdateServiceTitle(int serviceId, string serviceTitle);

        public List<GetAllServicesDTO> GetAllServices();
        public void AddServiceById(string title, int type, string duration, decimal price);
        public void UpdateServicePrice(int serviceId, decimal servicePrice);
    }
}
