using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Assets.Scripts.Controllers;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Services;
using Assets.Scripts.Core.UseCases.Responses;
using Assets.Scripts.Services.Scatterer;

namespace Assets.Scripts.Initialization.Commands
{
    internal class SceneBuilder : IInitializeAsync
    {
        private Dictionary<string, Meal> mealPrefabs = new();
        private Dictionary<string, Ingredient> ingredientPrefabs = new();
        private Dictionary<int, Ingredient> ingredientObjects = new();

        private readonly StorageLoader storageLoader;
        private readonly IngredientFacade ingredientFacade;
        private readonly MealFacade mealFacade;
        private readonly IngredientController ingredientController;
        private readonly DiContainer container;
        private readonly ItemScatterer itemScatterer;
        public SceneBuilder(
            DiContainer container, 
            StorageLoader storageLoader,
            IngredientFacade ingredientFacade,
            MealFacade mealFacade, 
            IngredientController ingredientController,
            ItemScatterer itemScatterer,
        IInitializeStepModifier stepModifier
        ) {
            this.container = container;
            this.storageLoader = storageLoader;
            this.ingredientFacade = ingredientFacade;
            this.mealFacade = mealFacade;
            this.ingredientController = ingredientController;
            ingredientController.OnBoughtIngredient += OnBoughtIngredient;
            this.itemScatterer = itemScatterer;
            stepModifier.AddSceneContextStep(this);
        }

        public Task<InitializeResult> Initialize()
        {
            try
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Debug.Log("SceneBuilder is initializing a scene..");
                var ingredients = ingredientFacade.GetIngredients();
                var meals = mealFacade.GetMeals();

                SetupPrefabMaps();

                var container = itemScatterer.transform;
                CreateIngredients(ingredients, container);
                CreateMeals(meals, container);
                itemScatterer.Scatter(ingredientObjects);
                sw.Stop();
                Debug.Log($"SceneBuilder initialized scene, time = {TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)}");
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
            var ingredient = ingredientObjects[response.Ingredient.Id];
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
                ingredientObjects.Add(ingredientsInput[i].Id, ingredient);
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
            var mealComponent = container.InstantiatePrefab(mealPrefabs[meal.Name], position, rotation, transform).GetComponent<Meal>();
            mealComponent.Init(meal.Id);
            return mealComponent;
        }
        private Ingredient Create(Core.Entities.Ingredient ingredient, Vector3 position, Quaternion rotation, Transform transform)
        {
            var ingredientComponent = container.InstantiatePrefab(ingredientPrefabs[ingredient.Name], position, rotation, transform).GetComponent<Ingredient>();
            ingredientComponent.Init(ingredient.Id);
            ingredientComponent.gameObject.SetActive(false);
            return ingredientComponent;
        }
    }


}
