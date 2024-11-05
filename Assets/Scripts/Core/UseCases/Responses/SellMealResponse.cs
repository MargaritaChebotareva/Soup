using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases.Responses
{
    public class SellMealResponse : BaseResponse
    {
        public int Money { get; }
        public Meal[] Meals { get; }
        public SellMealResponse(bool isSucces, int money, Meal[] meals, string error = "Ok") : base(isSucces, error)
        {
            Money = money;
            Meals = meals;
        }
    }
}
