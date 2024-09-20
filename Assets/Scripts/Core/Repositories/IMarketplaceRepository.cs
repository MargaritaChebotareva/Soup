using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.Repositories
{
    public interface IMarketplaceRepository
    {
        Ingredient GetIngredient(int id);
    }
}