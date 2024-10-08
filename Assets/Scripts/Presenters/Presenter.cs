using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.UseCases;
using System;

namespace Assets.Scripts.Presenters
{
    public class Presenter : IPresenter
    {
        public event Action<BuyIngredientResponse> OnBuyIngredientResponce;
        public event Action<PrepareMealResponse> OnPrepareMealResponse;
        public event Action<SellMealResponse> OnSellMealResponse;
        public event Action<InitializeResponse> OnInitializeResponse;
        public void Notify(BuyIngredientResponse buyIngredientResponse)
        {
            OnBuyIngredientResponce?.Invoke(buyIngredientResponse);
        }

        public void Notify(PrepareMealResponse prepareMealResponse)
        {
            OnPrepareMealResponse?.Invoke(prepareMealResponse);
        }

        public void Notify(SellMealResponse sellMealResponse)
        {
            OnSellMealResponse?.Invoke(sellMealResponse);
        }

        public void Notify(InitializeResponse initializeResponse)
        {
            OnInitializeResponse?.Invoke(initializeResponse);
        }
    }
}