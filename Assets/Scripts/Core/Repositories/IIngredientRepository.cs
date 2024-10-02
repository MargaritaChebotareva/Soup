using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.Repositories
{
    public interface IIngredientRepository
    {
        Ingredient GetIngredient(int id);

        void Remove(int id);

        void RemoveAny(string name);

        Ingredient[] GetIngredients(string name);

        Ingredient[] GetIngredients();

        void UpdateIngredient(Ingredient ingredient);

        void AddIngredient(string name, int price, Owner owner);

        void AddIngredients(Ingredient[] ingredients, Owner owner);

        void AddIngredientNames(string[] names);

        string[] GetIngredientsNames();
    }
}
