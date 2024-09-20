using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class SellDishResult
    {
        public bool IsSucces { get; }
        public Recipe Dish { get; }
        public SellDishResult(bool isSucces, Recipe dish)
        {
            IsSucces = isSucces;
            Dish = dish;
        }
    }
}
