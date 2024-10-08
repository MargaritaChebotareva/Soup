using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class SellMealResponse : BaseResponse
    {
        public int Money { get; }
        public Meal[] Meals { get; }
        public SellMealResponse(bool isSucces, int money, Meal[] meals) : base(isSucces)
        {
            Money = money;
            Meals = meals;
        }
    }
}
