namespace Assets.Scripts.Core.UseCases.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; }

        public string Error { get; }

        public BaseResponse(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
    }
}
