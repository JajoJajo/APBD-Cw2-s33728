using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service.UserService;

public interface IUserService
{
    void Add(User user);

    List<User> GetAll();

    User GetById(int id);
}