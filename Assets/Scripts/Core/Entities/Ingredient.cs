namespace Assets.Scripts.Core.Entities
{
    public class Ingredient
    {
        public int Id { get; }
        public string Name { get; }
        public Owner Owner { get; private set; }

        public Ingredient(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }

    }
}