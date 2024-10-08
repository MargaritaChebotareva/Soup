namespace Assets.Scripts.Core.Entities
{
    public class IngredientType
    {
        public string Name { get; }

        public int Price { get; }

        public IngredientType(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}