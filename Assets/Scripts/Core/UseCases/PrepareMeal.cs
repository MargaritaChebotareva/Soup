using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases.Responses;
using System.Collections.Generic;

namespace Assets.Scripts.Core.UseCases
{
    public class PrepareMeal
    {
        private IIngredientRepository ingredientRepository;
        private IMealRepository mealRepository;
        private IPresenter presenter;
        public PrepareMeal(IPresenter presenter, IMealRepository mealRepository, IIngredientRepository ingredientRepository)
        {
            this.presenter = presenter;
            this.mealRepository = mealRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public void Execute()
        {
            var recipes = mealRepository.GetRecipes();
            var countBefore = mealRepository.GetMealCount();

            foreach (var recipe in recipes)
            {
                if (CanPrepare(recipe.Composition))
                {
                    mealRepository.AddMeal(recipe);
                    for (int i = 0; i < recipe.Composition.Length; i++)
                    {
                        for (int k = 0; k < recipe.Composition[i].Count; k++)
                            ingredientRepository.RemoveAny(recipe.Composition[i].Name);
                    }
                }
            }
            var countAfter = mealRepository.GetMealCount();

            presenter.Notify(countBefore < countAfter ? new PrepareMealResponse(true, mealRepository.GetMeals()) : new PrepareMealResponse(false, null));
        }

        private bool CanPrepare(IngredientAmount[] composition)
        {
            Dictionary<string, int> ingredients = new Dictionary<string, int>();
            foreach (var ingredientAmount in composition)
            {
                var key = ingredientAmount.Name;
                if (ingredients.ContainsKey(key))
                {
                    ingredients[key] += ingredientAmount.Count;
                }
                else
                {
                    ingredients[key] = ingredientAmount.Count;
                }
            }

            var keys = ingredients.Keys;

            foreach (var key in keys)
            {
                var count = ingredientRepository.GetIngredients(key).Length;
                if (count < ingredients[key])
                {
                    return false;
                }
            }
            return true;
        }

    }

}
