using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Assets.Scripts.Services
{
    public class ScriptableObjectLoader
    {
        private IList<IResourceLocation> locationList;

        public async Task Init()
        {
            // handel will auto release
            var operation = Addressables.InitializeAsync();
            IResourceLocator resourceLocator = await operation.Task;

            var unloadedLocations = Addressables.LoadResourceLocationsAsync(resourceLocator.Keys, Addressables.MergeMode.Union);
            locationList = await unloadedLocations.Task;
            Addressables.Release(unloadedLocations);
        }

        private IResourceLocation FindResourceLocation(Type type)
        {
            return locationList.FirstOrDefault(x => x.ResourceType == type);
        }

        public async Task<T> Get<T>()
        {
            var location = FindResourceLocation(typeof(T));
            var operation = Addressables.LoadAssetAsync<T>(location);
            var t = await operation.Task;
            Addressables.Release(operation);
            return t;
        }
    }
}
