namespace Assets.Scripts.Core.UseCases.Requests
{
    public class BuyIngredientRequest
    {
        public int Id { get; }
        public BuyIngredientRequest(int id)
        {
            Id = id;
        }
    }
}
