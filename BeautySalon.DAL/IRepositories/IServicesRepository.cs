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
        public List<ServicesDTO> GetServicesWithPriceAndDurationByTypeId(int typeId);
        public List<GetAllServicesByIdFromCurrentTypeDTO> GetAllServicesByIdFromCurrentType(int id);
        public void UpdateServiceTitle(int serviceId, string serviceTitle);

        public List<GetAllServicesDTO> GetAllServices();
        public void AddServiceById(AddServiceByIdDTO model);
        public void UpdateServicePrice(int serviceId, decimal servicePrice);
        public void RemoveServiceById(int id);
        public List<AllFreeIntervalsOnCurrentServiceDTO> GetAllFreeIntervalsOnCurrentService(int serviceId);
    }
}
