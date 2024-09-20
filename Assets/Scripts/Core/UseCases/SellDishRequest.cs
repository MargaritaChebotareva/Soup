namespace Assets.Scripts.Core.UseCases
{
    public class SellDishRequest
    {
        public int Id { get; }
        public SellDishRequest(int id)
        {
            Id = id;
        }
    }
}
