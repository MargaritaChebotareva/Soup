using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using System.Collections.Generic;

namespace Assets.Scripts.Core.UseCases
{
    public class PrepareDish
    {
        private IUserRepository userRepository;
        private IPresenter presenter;
        public PrepareDish(IUserRepository userRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.presenter = presenter;
        }

        public void Execute()
        {
            var user = userRepository.GetUser();
            var recipes = user.AvailableRecipes;

            List<Recipe> dishes = new List<Recipe>();

            foreach (var recipe in recipes)
            {
                if (TryPrepare(user, recipe))
                {
                    dishes.Add(recipe);
                }
            }
            userRepository.UpdateUser(user);
            presenter.Notify(dishes.Count > 0 ? new PrepareDishResult(true, dishes) : new PrepareDishResult(false, null));
        }

        private bool TryPrepare(User user, Recipe recipe)
        {
            Dictionary<string, int> ingredients = new Dictionary<string, int>();
            foreach (RecipePair recipePair in recipe.Composition)
            {
                var key = recipePair.Ingredient.Name;
                if (ingredients.ContainsKey(key))
                {
                    ingredients[key] += recipePair.Count;
                }
                else
                {
                    ingredients[key] = recipePair.Count;
                }
            }
            var keys = ingredients.Keys;

            foreach (var key in keys)
            {
                var count = user.Ingredients.FindAll(x => x.Name == key).Count;
                if (count < ingredients[key])
                {
                    return false;
                }
            }

            foreach (var key in keys)
            {
                while (ingredients[key] > 0)
                {
                    var index = user.Ingredients.FindIndex(x => x.Name == key);
                    user.Ingredients.RemoveAt(index);
                    ingredients[key]--;
                }
            }
            return true;

        }

    }

}
