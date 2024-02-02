using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IUserRepository
{
    public List<UsersDTO> GetAllEmployees();
    public List<UsersDTO> GetClientByNameAndId(string name, int id);
}