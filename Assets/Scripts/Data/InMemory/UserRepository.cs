using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Data.InMemory
{
    public class UserRepository : IUserRepository
    {
        private User user;
        public User Create(int money)
        {
            user = new User(money);
            return user;
        }

        public User Get()
        {
            return user;
        }

        public void Update(User user)
        {
            this.user = user;
        }
    }
}
