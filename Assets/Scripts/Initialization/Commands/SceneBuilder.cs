using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Assets.Scripts.Controllers;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Services;
using Assets.Scripts.Core.UseCases.Responses;

namespace Assets.Scripts.Initialization.Commands
{
    internal class SceneBuilder : IInitializeAsync
    {
        private Dictionary<string, Meal> mealPrefabs = new();
        private Dictionary<string, Ingredient> ingredientPrefabs = new();
        private Dictionary<int, Ingredient> ingredientMap = new();

        private readonly StorageLoader storageLoader;
        private readonly IngredientFacade ingredientFacade;
        private readonly MealFacade mealFacade;
        private readonly IngredientController ingredientController;
        private readonly DiContainer container;
        public SceneBuilder(
            DiContainer container, 
            StorageLoader storageLoader,
            IngredientFacade ingredientFacade,
            MealFacade mealFacade, 
            IngredientController ingredientController
        ) {
            this.container = container;
            this.storageLoader = storageLoader;
            this.ingredientFacade = ingredientFacade;
            this.mealFacade = mealFacade;
            this.ingredientController = ingredientController;
            ingredientController.OnBoughtIngredient += OnBoughtIngredient;
        }

        public Task<InitializeResult> Initialize()
        {
            try
            {
                Debug.Log("SceneBuilder is initializing a scene..");
                var ingredients = ingredientFacade.GetIngredients();
                var meals = mealFacade.GetMeals();

                SetupPrefabMaps();
                var container = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects()[0].transform;
                CreateIngredients(ingredients, container);
                CreateMeals(meals, container);
                
                Debug.Log("SceneBuilder initialized scene");
                return Task.FromResult(new InitializeResult(true, null));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new InitializeResult(false, ex.Message));
            }
        }

        private void OnBoughtIngredient(BuyIngredientResponse response)
        {
            if (!response.IsSuccess) return;
            var ingredient = ingredientMap[response.Ingredient.Id];
            ingredient.SetAsUser();

        }

        private void SetupPrefabMaps()
        {
            foreach (var item in storageLoader.Meals.GetPrefabs())
            {
                mealPrefabs.Add(item.Name, item.Prefab);
            }
            foreach (var item in storageLoader.Ingredients.GetPrefabs())
            {
                ingredientPrefabs.Add(item.Name, item.Prefab);
            }
        }
        private void CreateIngredients(Core.Entities.Ingredient[] ingredientsInput, Transform container)
        {
            for (int i = 0; i < ingredientsInput.Length; i++)
            {
                var ingredient = Create(ingredientsInput[i], default, default, container);

                if (ingredientsInput[i].Owner == Core.Entities.Owner.User)
                {
                    ingredient.SetAsUser();
                }
                else
                {
                    ingredient.SetAsNone();
                }
                ingredient.Init(ingredientsInput[i].Id);
                ingredientMap.Add(ingredientsInput[i].Id, ingredient);
            }
        }
        private void CreateMeals(Core.Entities.Meal[] mealsInput, Transform container)
        {
            for (int i = 0; i < mealsInput.Length; i++)
            {
                Create(mealsInput[i], default, default, container);
            }
        }
        private Meal Create(Core.Entities.Meal meal, Vector3 position, Quaternion rotation, Transform transform)
        {
            var mealComponent = container.InstantiatePrefab(mealPrefabs[meal.Name], position, rotation, transform).GetComponent<Prefabs.Meal>();
            mealComponent.Init(meal.Id);
            return mealComponent;
        }
        private Ingredient Create(Core.Entities.Ingredient ingredient, Vector3 position, Quaternion rotation, Transform transform)
        {
            var ingredientComponent = container.InstantiatePrefab(ingredientPrefabs[ingredient.Name], position, rotation, transform).GetComponent<Prefabs.Ingredient>();
            ingredientComponent.Init(ingredient.Id);
            return ingredientComponent;
        }
    }
}
