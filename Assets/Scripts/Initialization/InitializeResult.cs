namespace Assets.Scripts.Initialization
{
    public struct InitializeResult
    {
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }
        public InitializeResult(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
    }
}
