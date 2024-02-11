using BeautySalon.BLL.Models.Output_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Clents
{
    public class ServiceClient
    {
        
        public ServiceClient()
        {
            _serviceRepository = new ServiceRepository();
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }
        public  void AddService()
        {
            //ggs
        }
        //public List<> GetAllFreeIntervalsOnCurrentService() 
        //{
        //}

    }
}
