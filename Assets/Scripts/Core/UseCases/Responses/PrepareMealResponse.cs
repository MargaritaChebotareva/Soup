using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases.Responses
{
    public class PrepareMealResponse : BaseResponse
    {
        public Meal[] Meals { get; }
        public PrepareMealResponse(bool isSucces, Meal[] meals, string error = "Ok") : base(isSucces, error)
        {
            Meals = meals;
        }
    }

}
