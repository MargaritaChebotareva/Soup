namespace Assets.Scripts.Core.Entities
{
    public class Recipe
    {
        public string Name { get; }
        public IngredientAmount[] Composition { get; }
        public int Price { get; }

        public Recipe(string name, IngredientAmount[] composition, int price)
        {
            Name = name;
            Composition = composition;
            Price = price;
        }
    }
}