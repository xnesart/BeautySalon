using BeautySalon.BLL.IClient;
using AutoMapper;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL.Clents
{
    public class ServiceClient : IServiceClient
    {
        private ServicesRepository _servicesRepository;
        private Mapper _mapper;

        public ServiceClient()
        {
            _servicesRepository = new ServicesRepository();
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }

        public void AddServiceByIdInputModel(ServiceByIdInputModel model)
        {
            AddServiceByIdDTO dto = _mapper.Map<AddServiceByIdDTO>(model);
            _servicesRepository.AddServiceById(dto);
        }
    }
}