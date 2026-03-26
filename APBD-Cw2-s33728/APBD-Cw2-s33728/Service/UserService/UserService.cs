using System.Collections.Generic;
using System.Linq;
using APBD_Cw2_s33728.Exceptions;
using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service.UserService;

public class UserService : IUserService
{
    private readonly List<User> _users = [];

    public void Add(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User GetById(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return user ?? throw new UserNotFoundException(id);
    }
}