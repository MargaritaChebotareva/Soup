using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.UseCases.Responses;
using System;

namespace Assets.Scripts.Presenters
{
    public class Presenter : IPresenter
    {
        public event Action<BuyIngredientResponse> OnBuyIngredientResponse;
        public event Action<PrepareMealResponse> OnPrepareMealResponse;
        public event Action<SellMealResponse> OnSellMealResponse;

        public void Notify(BuyIngredientResponse buyIngredientResponse)
        {
            OnBuyIngredientResponse?.Invoke(buyIngredientResponse);
        }

        public void Notify(PrepareMealResponse prepareMealResponse)
        {
            OnPrepareMealResponse?.Invoke(prepareMealResponse);
        }

        public void Notify(SellMealResponse sellMealResponse)
        {
            OnSellMealResponse?.Invoke(sellMealResponse);
        }
    }
}