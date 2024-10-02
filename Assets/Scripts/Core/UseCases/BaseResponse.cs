namespace Assets.Scripts.Core.UseCases
{
    public class BaseResponse
    {
        public bool IsSuccess { get; }
        public BaseResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
