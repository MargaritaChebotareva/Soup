using System;

namespace Assets.Scripts.Initialization
{
    public struct InitializeResult
    {
        public bool IsSuccess { get; private set; }
        public Exception Error { get; private set; }
        public InitializeResult(bool isSuccess, Exception error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
    }
}
