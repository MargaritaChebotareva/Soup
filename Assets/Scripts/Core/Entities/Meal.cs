namespace Assets.Scripts.Core.Entities
{
    public class Meal
    {
        public int Id {  get; }
        public string Name { get; }

        public Meal(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}