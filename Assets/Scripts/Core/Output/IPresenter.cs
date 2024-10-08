using Assets.Scripts.Core.UseCases;
using System;

namespace Assets.Scripts.Core.Output
{
    public interface IPresenter
    {
        event Action<BuyIngredientResponse> OnBuyIngredientResponce;
        event Action<PrepareMealResponse> OnPrepareMealResponse;
        event Action<SellMealResponse> OnSellMealResponse;
        event Action<InitializeResponse> OnInitializeResponse;
        void Notify(BuyIngredientResponse buyIngredientResponse);
        void Notify(PrepareMealResponse prepareMealResponse);
        void Notify(SellMealResponse sellMealResponse);
        void Notify(InitializeResponse initializeResponse);
    }
}
