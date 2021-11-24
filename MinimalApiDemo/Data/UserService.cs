using MinimalApiDemo.model;

namespace MinimalApiDemo.Data
{
  public class UserService : IUserService
  {
    private readonly Dictionary<Guid, User> _users = new();
    public void CreateUser(User? user)
    {
      if (user == null)
      {
        return;
      }
      _users[user.Id] = user;
    }

    public User? GetUser(Guid id)
    {
      return _users.GetValueOrDefault(id);
    }

    public List<User> GetUsers()
    {
      return _users.Values.ToList();
    }
  }
}
