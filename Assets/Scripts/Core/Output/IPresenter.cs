using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Core.Output
{
    public interface IPresenter
    {
        void Notify(BuyIngredientResult buyIngredientResult);
        void Notify(PrepareMealResult prepareMealResult);
        void Notify(SellMealResult sellMealResult);
    }
}
