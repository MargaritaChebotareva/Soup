using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Initialization
{
    internal class ApplicationInitializer : IInitializeProgress, IInitializable
    {
        public event Action Initialized;
        public event Action<string> InitializationFailed;
        public event Action<float> ProgressChanged;
        public event Action Initializing;

        private readonly IEnumerable<IInitializeAsync> steps;

        public ApplicationInitializer(IEnumerable<IInitializeAsync> steps)
        {
            this.steps = steps;
        }

        public async Task Initialize()
        {
            Initializing?.Invoke();
            int stepNumber = 0;
            float count = steps.Count();
            foreach (var step in steps)
            {
                stepNumber++;
                var result = await step.Initialize();
                if (!result.IsSuccess)
                {
                    InitializationFailed?.Invoke(result.Error);
                    return;
                }
                ProgressChanged?.Invoke(stepNumber / count);
            }
            Initialized?.Invoke();
        }

        async void IInitializable.Initialize()
        {
            await Initialize();
        }
    }
}
