namespace Assets.Scripts.Core.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Ingredient(int id, string name, int price) { 
            Id = id;
            Name = name;
            Price = price;
        }
    }
}