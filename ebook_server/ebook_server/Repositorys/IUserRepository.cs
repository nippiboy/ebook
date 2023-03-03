using ebook_server.Entitys;

namespace ebook_server.Repositorys
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userName);
        Task SaveUser(User user);
    }
}
