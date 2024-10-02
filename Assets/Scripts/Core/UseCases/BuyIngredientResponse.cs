using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class BuyIngredientResponse : BaseResponse
    {
        public User User { get; }

        public Ingredient Ingredient { get; }

        public BuyIngredientResponse(bool isSuccess, User user, Ingredient ingredient) : base(isSuccess)
        {
            User = user;
            Ingredient = ingredient;
        }
    }
}
