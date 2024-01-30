using BeautySalon.DAL.DTO;

namespace BeautySalon.DAL.IRepositories;

public interface IUserRepository
{
    public List<UsersDTO> GetAllEmployees();
}