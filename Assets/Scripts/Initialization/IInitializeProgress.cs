using System;

namespace Assets.Scripts.Initialization
{
    internal interface IInitializeProgress
    {
        event Action Initializing;
        event Action Initialized;
        event Action<string> InitializationFailed;
        event Action<float> ProgressChanged;
    }
}
