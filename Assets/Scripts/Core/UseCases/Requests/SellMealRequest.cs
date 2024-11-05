namespace Assets.Scripts.Core.UseCases.Requests
{
    public class SellMealRequest
    {
        public int Id { get; }
        public SellMealRequest(int id)
        {
            Id = id;
        }
    }
}
