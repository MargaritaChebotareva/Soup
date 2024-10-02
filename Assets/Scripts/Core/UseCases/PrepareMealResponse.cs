using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class PrepareMealResponse : BaseResponse
    {
        public Meal[] Meals { get; }
        public PrepareMealResponse(bool isSucces, Meal[] meals) : base(isSucces)
        {
            Meals = meals;
        }
    }

}
