using BeautySalon.BLL.Models.Output_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.BLL.Models.InputModels;

namespace BeautySalon.BLL.IClient
{
    public interface IServiceClient
    {
        public List<AllServicesByIdFromCurrentTypeOutputModel> GetAllServicesByIdFromCurrentType(int id);
        public List<AllServicesOutputModel> GetAllServices();
        public void UpdateServiceTitle(ServiceIdAndServiceTitleInputModel model);   
        public void UpdateServicePrice(ServiceIdAndServicePriceInputModel model);   
        public void UpdateServiceDuration(ServiceIdAndServiceDurationInputModel model);   
    }
}
