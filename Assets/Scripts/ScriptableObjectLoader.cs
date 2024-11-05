using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Assets.Scripts
{
    public class ScriptableObjectLoader
    {
        private IList<IResourceLocation> locationList;

        public async Task Init()
        {
            if (locationList != null) return;
            // handel will auto release
            var operation = Addressables.InitializeAsync();
            IResourceLocator resourceLocator = await operation.Task;
            var unloadedLocations = Addressables.LoadResourceLocationsAsync(resourceLocator.Keys, Addressables.MergeMode.Union);
            locationList = await unloadedLocations.Task;
            Addressables.Release(unloadedLocations);
        }

        public async Task<T> Get<T>(bool release = true)
        {
            var location = FindResourceLocation(typeof(T));
            var operation = Addressables.LoadAssetAsync<T>(location);
            var t = await operation.Task;
            if (release) Addressables.Release(operation);
            return t;
        }

        private IResourceLocation FindResourceLocation(Type type)
        {
            return locationList.FirstOrDefault(x => x.ResourceType == type);
        }
    }
}
