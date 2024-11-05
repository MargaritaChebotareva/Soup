using UnityEngine;

namespace Assets.Scripts.Initialization
{
    internal class ApplicationInitializerLog
    {
        private readonly IInitializeProgress progress;
        public ApplicationInitializerLog(IInitializeProgress progress)
        {
            this.progress = progress;
            this.progress.Initializing += OnInitializing;
            this.progress.ProgressChanged += OnProgressChanged;
            this.progress.InitializationFailed += OnInitializationFailed;
            this.progress.Initialized += OnInitialized;
        }

        private void OnInitialized()
        {
            Debug.Log($"Application is initialized!");
        }

        private void OnInitializationFailed(string error)
        {
            Debug.Log($"Application is failed, error: {error}");
        }

        private void OnProgressChanged(float value)
        {
            Debug.Log($"..progress is {value * 100:00}% ..");
        }

        private void OnInitializing()
        {
            Debug.Log($"Application is initializing..");
        }
    }
}
