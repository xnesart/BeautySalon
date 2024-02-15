using AutoMapper;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models.InputModels;
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
    public class TypeClient :ITypeClient
    {
        private ITypesRepository _typesRepository;
        private Mapper _mapper;

        public TypeClient()
        {
            _typesRepository = new TypesRepository();
            IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }
        public List<AllServiceTypeOutputModel> GetAllServiceTypes()
        {
            List<TypesDTO> types = this._typesRepository.GetAllServiceTypes();
            List<AllServiceTypeOutputModel> result = this._mapper.Map<List<AllServiceTypeOutputModel>>(types);
            return result;  
        }
    }
}
