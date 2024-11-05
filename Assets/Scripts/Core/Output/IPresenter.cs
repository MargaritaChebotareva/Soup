using Assets.Scripts.Core.UseCases.Responses;
using System;

namespace Assets.Scripts.Core.Output
{
    public interface IPresenter
    {
        event Action<BuyIngredientResponse> OnBuyIngredientResponse;
        event Action<PrepareMealResponse> OnPrepareMealResponse;
        event Action<SellMealResponse> OnSellMealResponse;
        void Notify(BuyIngredientResponse buyIngredientResponse);
        void Notify(PrepareMealResponse prepareMealResponse);
        void Notify(SellMealResponse sellMealResponse);
    }
}
