using System.Collections.Generic;

namespace Assets.Scripts.Core.Entities
{
    public class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<RecipePair> Composition { get; private set; }
        public int Price { get; private set; }

        public Recipe(int id, string name, List<RecipePair> composition, int price)
        {
            Id = id;
            Name = name;
            Composition = composition;
            Price = price;
        }
    }
}