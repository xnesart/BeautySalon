using BeautySalon.BLL.Models.Output_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.IClient
{
    public interface IServiceClient
    {
        public List<AllServicesByIdFromCurrentTypeOutputModel> GetAllServicesByIdFromCurrentType(int id);
        public List<AllServicesOutputModel> GetAllServices();
    }
}
