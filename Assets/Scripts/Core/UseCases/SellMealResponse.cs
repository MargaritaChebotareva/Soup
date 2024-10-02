using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class SellMealResponse : BaseResponse
    {
        public Meal[] Meals { get; }
        public SellMealResponse(bool isSucces, Meal[] meals) : base(isSucces)
        {
            Meals = meals;
        }
    }
}
