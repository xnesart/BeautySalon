using AutoMapper;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL;

public class UserClient
{
    private UserRepository _userRepository;
    private Mapper _mapper;

    public UserClient()
    {
        _userRepository = new UserRepository();
        var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }
    
    public List<AllWorkersByRoleIdOutputModel> GetAllWorkersByRoleId()
    {
        List<UsersDTO> users =
            _userRepository.GetAllWorkersByRoleId();
        var result = _mapper.Map<List<AllWorkersByRoleIdOutputModel>>(users);
        return result;
    }
}