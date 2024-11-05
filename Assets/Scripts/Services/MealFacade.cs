using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Services
{
    public class MealFacade
    {
        private IMealRepository mealRepository;
        public MealFacade(IMealRepository mealRepository)
        {
            this.mealRepository = mealRepository;
        }

        public Meal[] GetMeals()
        {
            return mealRepository.GetMeals();
        }
    }
}
