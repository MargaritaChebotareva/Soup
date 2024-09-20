using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Core.Output
{
    public interface IPresenter
    {
        void Notify(BuyIngredientResult buyIngredientResult);
        void Notify(PrepareDishResult prepareDishResult);
        void Notify(SellDishResult sellDishResult);
    }
}
