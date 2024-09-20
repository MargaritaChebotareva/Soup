namespace Assets.Scripts.Core.Entities
{
    public class RecipePair
    {
        public Ingredient Ingredient { get; private set; }
        public int Count { get; private set; }

        public RecipePair(Ingredient ingredient, int count)
        {
            Ingredient = ingredient;
            Count = count;
        }
    }
}