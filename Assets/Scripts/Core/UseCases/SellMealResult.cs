using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class SellMealResult
    {
        public bool IsSucces { get; }
        public Recipe Meal { get; }
        public SellMealResult(bool isSucces, Recipe meal)
        {
            IsSucces = isSucces;
            Meal = meal;
        }
    }
}
