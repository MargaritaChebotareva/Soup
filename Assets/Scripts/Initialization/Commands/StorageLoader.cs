using Assets.Scripts.Initialization;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class StorageLoader : IInitializeAsync
    {
        public Ingredients Ingredients { get; private set; }
        public Meals Meals { get; private set; }
        public StartingIngredients StartingIngredients { get; private set; }
        public StartingUserValues StartingUserValues { get; private set; }

        public async Task<InitializeResult> Initialize()
        {
            try
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Debug.Log("Storage is initializing..");
                ScriptableObjectLoader scriptableObjectLoader = new ScriptableObjectLoader();
                await scriptableObjectLoader.Init();
                Ingredients = await scriptableObjectLoader.Get<Ingredients>(false);
                Meals = await scriptableObjectLoader.Get<Meals>(false);
                StartingIngredients = await scriptableObjectLoader.Get<StartingIngredients>();
                StartingUserValues = await scriptableObjectLoader.Get<StartingUserValues>();
                sw.Stop();
                Debug.Log($"Storage is initialized, time = {TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)}");
                return new InitializeResult(true, null);
            }
            catch (Exception ex)
            {
                return new InitializeResult(false, ex.Message);
            }
        }
    }
}
