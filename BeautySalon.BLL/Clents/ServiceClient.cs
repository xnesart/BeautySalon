
using AutoMapper;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.Clents
{
    public class ServiceClient :IServiceClient
    {
        private IServicesRepository _servicesRepository;
        private Mapper _mapper;

        public ServiceClient()
        {
            _servicesRepository = new ServicesRepository();
            IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }



    }
}
