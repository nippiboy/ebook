using ebook_server.DTOs;
using ebook_server.Entitys;
using ebook_server.Helper;

namespace ebook_server.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        public UserRepository() {
            _users = new List<User>()
            {
                new User() {UserName = "user1", UserEmail = "teszt@valami.com", UserPassword = "teszt", CreditAmount = 0},
                new User() {UserName = "user2", UserEmail = "teszt2@valami.com", UserPassword = "teszt", CreditAmount = 100},
            };
        }

        public async Task<User> GetUser(string userName)
        {
            await Task.Delay(1000);
            User user = _users.FirstOrDefault(user => user.UserName == userName);
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            await Task.Delay(1000);
            return _users;
        }

        public async Task SaveUser(User user)
        {
            await Task.Delay(1000);
            _users.Add(user);
        }
    }
}
