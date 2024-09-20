using System.Collections.Generic;

namespace Assets.Scripts.Core.Entities
{
    public class Marketplace
    {
        public List<Ingredient> Ingredients { get; private set; }

        public Marketplace(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
