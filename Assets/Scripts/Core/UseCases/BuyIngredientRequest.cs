namespace Assets.Scripts.Core.UseCases
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
