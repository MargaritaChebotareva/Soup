using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases.Responses
{
    public class BuyIngredientResponse : BaseResponse
    {
        public User User { get; }

        public Ingredient Ingredient { get; }

        public BuyIngredientResponse(bool isSuccess, User user, Ingredient ingredient, string error = "Ok") : base(isSuccess, error)
        {
            User = user;
            Ingredient = ingredient;
        }
    }
}
