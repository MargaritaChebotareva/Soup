namespace Assets.Scripts.Core.Entities
{
    public class IngredientAmount
    {
        public string Name { get; }
        public int Count { get; }

        public IngredientAmount(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}