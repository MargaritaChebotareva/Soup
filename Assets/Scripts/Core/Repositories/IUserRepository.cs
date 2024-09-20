using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUser();
        void UpdateUser(User user);
    }
}