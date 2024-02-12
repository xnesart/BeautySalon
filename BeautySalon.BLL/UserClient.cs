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

    public List<GetAllWorkersByRoleIdInputModel> GetAllWorkersByRoleId()
    {
        List<UsersDTO> users =
            _userRepository.GetAllWorkersByRoleId();
        var result = _mapper.Map<List<GetAllWorkersByRoleIdInputModel>>(users);
        return result;
    }

    public List<GetClientByNameAndIdInputModel> GetClientByNameAndId(string name, int id)
    {
        List<UsersDTO> users =
            _userRepository.GetClientByNameAndId(name, id);
        var result = _mapper.Map<List<GetClientByNameAndIdInputModel>>(users);
        return result;
    }

    public void AddUserByChatId(int chatId, string userName, string name, string phone, string mail,
        int roleId, decimal salary, int isBlocked, int isDeleted)
    {
        List<UsersDTO> users =
            _userRepository.AddUserByChatId(chatId, userName, name, phone, mail,
                roleId, salary, isBlocked, isDeleted);
    }
    
    public List<GetClientByNameAndPhoneInputModel> GetClientByNameAndPhone(string name, string phone)
    {
        List<UsersDTO> users =
            _userRepository.GetClientByNameAndPhone(name,phone);
        var result = _mapper.Map<List<GetClientByNameAndPhoneInputModel>>(users);
        return result;
    }
}