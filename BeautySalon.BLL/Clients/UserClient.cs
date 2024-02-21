using System.Collections.Generic;
using AutoMapper;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Mapping;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;

namespace BeautySalon.BLL;

public class UserClient : IUserClient
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

    public List<ClientByNameAndIdOutputModel> GetClientByNameAndId(string name, int id)
    {
        List<UsersDTO> users =
            _userRepository.GetClientByNameAndId(name, id);
        var result = _mapper.Map<List<ClientByNameAndIdOutputModel>>(users);
        return result;
    }

    public void AddUserByChatId(AddUserByChatIdInputModel model)
    {
        UsersDTO dto = _mapper.Map<UsersDTO>(model);
        List<UsersDTO> users =
            _userRepository.AddUserByChatId(dto);
    }
    
    public List<ClientByNameAndPhoneOutputModel> GetClientByNameAndPhone(string name, string phone)
    {
        List<UsersDTO> users =
            _userRepository.GetClientByNameAndPhone(name,phone);
        var result = _mapper.Map<List<ClientByNameAndPhoneOutputModel>>(users);
        return result;
    }  
    
    public List<MasterByNameAndIdOutputModel> GetMasterByNameAndId(string name, int id)
    {
        List<UsersDTO> users =
            _userRepository.GetMasterByNameAndId(name,id);
        var result = _mapper.Map<List<MasterByNameAndIdOutputModel>>(users);
        return result;
    }   
    
    public List<MasterByNameAndPhoneOutputModel> GetMasterByNameAndPhone(string name, string phone)
    {
        List<UsersDTO> users =
            _userRepository.GetMasterByNameAndPhone(name,phone);
        var result = _mapper.Map<List<MasterByNameAndPhoneOutputModel>>(users);
        return result;
    }

    public List<UserByChatIdOutputModel> GetUserByChatId(int chatId)
    {
        List<UsersDTO> users =
            _userRepository.GetUserByChatId(chatId);
        var result = _mapper.Map<List<UserByChatIdOutputModel>>(users);
        return result;
    }

    public List<AllWorkersWithContactsByUserIdOutputModel> GetAllWorkersWithContactsByUserId()
    {
        List<GetAllWorkersWithContactsByUserIdDTO> users =
            _userRepository.GetAllWorkersWithContactsByUserId();
        var result = _mapper.Map<List<AllWorkersWithContactsByUserIdOutputModel>>(users);
        return result;
    } 
    
    public void AddWorkerByRoleId(WorkerByRoleIdInputModel model)
    {
        AddWorkerByRoleIdDTO dto = _mapper.Map<AddWorkerByRoleIdDTO>(model);
        _userRepository.AddWorkerByRoleId(dto);
    }  
    
    public List<AllChatIdOutputModel> GetAllChatId()
    {
        List<GetAllChatIdDTO> chats =
            _userRepository.GetAllChatId();
        var result = _mapper.Map<List<AllChatIdOutputModel>>(chats);
        return result;
    }
    
    public UserIsDeletedOutputModel RemoveUserById(UserIdInputModel model)
    {
        IUserRepository userRepository = new UserRepository();
        UsersDTO dto = userRepository.RemoveUserById(model.Id);
        var result = _mapper.Map<UserIsDeletedOutputModel>(dto);
        return result;
    }

    public void RemoveMasterFromShift(int masterId, int shiftId)
    {
        _userRepository.RemoveMasterFromShift(masterId, shiftId);
    }

    public void ChangeMasterInShift(int masterId, int shiftId)
    {
        _userRepository.ChangeMasterInShift(masterId, shiftId);
    }
    public List<CheckAndAddUserOutputModel> CheckAndAddUser(int chatId)
    {
        List<UsersDTO> userChatId = this._userRepository.CheckAndAddUser(chatId);
        
        var result = this._mapper.Map<List<CheckAndAddUserOutputModel>>(userChatId).ToList();
        
        return result;
    }
    
    public int GetFreeMasterByIntervalIdNew(int intervalId)
    {
        List<GetFreeMasterIdByIntervalIdDTO> masterList = _userRepository.GetFreeMasterIdByIntervalId(intervalId);
        
        var result = this._mapper.Map<List<MasterIdOutputModel>>(masterList).ToList();
        foreach (var item in result)
        {
            return item.MasterId;
        }
        return -1;
    }

}