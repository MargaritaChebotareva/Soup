using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Core.Output
{
    public interface IPresenter
    {
        void Notify(BuyIngredientResponse buyIngredientResponse);
        void Notify(PrepareMealResponse prepareMealResponse);
        void Notify(SellMealResponse sellMealResponse);
        void Notify(InitializeResponse initializeResponse);
    }
}
