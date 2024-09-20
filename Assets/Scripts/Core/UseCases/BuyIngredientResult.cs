using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class BuyIngredientResult
    {
        public bool IsSucces { get; }
        public User User { get; }

        public Ingredient Ingredient { get; }

        public BuyIngredientResult(bool isSuccess, User user, Ingredient ingredient)
        {
            IsSucces = isSuccess;
            User = user;
            Ingredient = ingredient;
        }
    }
}
