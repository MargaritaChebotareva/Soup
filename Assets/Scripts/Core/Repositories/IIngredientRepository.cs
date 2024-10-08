using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.Repositories
{
    public interface IIngredientRepository
    {
        Ingredient GetIngredient(int id);

        Ingredient[] GetIngredients(string name);

        Ingredient[] GetIngredients();

        void UpdateIngredient(Ingredient ingredient);

        void AddIngredient(string name, Owner owner);

        void AddIngredients(Ingredient[] ingredients, Owner owner);

        void Remove(int id);

        void RemoveAny(string name);

        void AddIngredientTypes(IngredientType[] types);

        IngredientType[] GetIngredientTypes();

        IngredientType GetIngredientType(string name);
    }
}
