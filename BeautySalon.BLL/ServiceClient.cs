using BeautySalon.BLL.Models.Output_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL
{
    public class ServiceClient
    {
        public ServiceClient()
        {
            _serviceRepository = new ServiceRepository();
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }

        public List<AllFreeIntervalsOnCurrentServiceOutputModel> GetAllFreeIntervalsOnCurrentService(int serviceId)
        {
            List<ServicesDTO> services = _serviceRepository.GetAllFreeIntervalsOnCurrentService(serviceId);
            var result = _mapper.Map<List<IntеrvalsDTO>>(intervals);
            return result;


        }
    }
}
