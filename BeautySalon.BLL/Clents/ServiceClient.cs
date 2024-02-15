
using AutoMapper;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;
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
        public List<AllServicesByIdFromCurrentTypeOutputModel> GetAllServicesByIdFromCurrentType(int id)
        {
            List< GetAllServicesByIdFromCurrentTypeDTO> getAllServices = this._servicesRepository.GetAllServicesByIdFromCurrentType(id);
            List<AllServicesByIdFromCurrentTypeOutputModel> result = this._mapper.Map<List<AllServicesByIdFromCurrentTypeOutputModel>>(getAllServices);
            return result;
        }
        public List<AllServicesOutputModel> GetAllServices()
        {
            List< GetAllServicesDTO> allServices = this._servicesRepository.GetAllServices();
            List<AllServicesOutputModel> result = this._mapper.Map<List<AllServicesOutputModel>>(allServices);
            return result;
        }


    }
}
