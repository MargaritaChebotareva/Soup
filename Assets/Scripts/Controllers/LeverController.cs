using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Controllers
{
    public class LeverController
    {
        private IUserRepository userRepository;
        private IPresenter presenter;

        public void ClickOnLever()
        {
            var prepareMeal = new PrepareMeal(userRepository, presenter);
            prepareMeal.Execute();
        }
    }
}