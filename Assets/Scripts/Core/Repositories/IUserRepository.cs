using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.Repositories
{
    public interface IUserRepository
    {
        User Create(int money);

        void Update(User user);

        User Get();
    }
}
