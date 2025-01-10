using Assets.Scripts.Core.UseCases;
using Assets.Scripts.Core.UseCases.Requests;
using Assets.Scripts.Initialization;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class RepositoryInitializer : IInitializeAsync
    {
        private Initialize initialize;
        private StorageLoader storageLoader;

        public RepositoryInitializer(Initialize initialize, StorageLoader storageLoader)
        {
            this.initialize = initialize;
            this.storageLoader = storageLoader;
        }

        public Task<InitializeResult> Initialize()
        {
            try
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Debug.Log("RepositoryInitializer is initializing..");
                initialize.Execute(new InitializeRequest(
                    storageLoader.StartingUserValues.Money,
                    storageLoader.Ingredients.GetIngredientTypes(),
                    storageLoader.StartingIngredients.GetIngredients(),
                    storageLoader.Meals.GetRecipes()));
                sw.Stop();
                Debug.Log($"RepositoryInitializer is initialized, time = {TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)}");
                return Task.FromResult(new InitializeResult(true, null));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new InitializeResult(false, ex.Message));
            }
        }
    }
}
