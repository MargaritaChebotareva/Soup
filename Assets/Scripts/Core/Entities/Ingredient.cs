namespace Assets.Scripts.Core.Entities
{
    public class Ingredient
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public Owner Owner { get; private set; }

        public Ingredient(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }

    }
}