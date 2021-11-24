using MinimalApiDemo.model;

namespace MinimalApiDemo.Data
{
  public interface IUserService
  {
    void CreateUser(User? user);
    List<User> GetUsers();
    User? GetUser(Guid id);
  }
}
