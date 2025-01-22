using System;

namespace Assets.Scripts.Initialization
{
    internal interface IInitializeProgress
    {
        event Action Initializing;
        event Action Initialized;
        event Action<Exception> InitializationFailed;
        event Action<float> ProgressChanged;
    }
}
