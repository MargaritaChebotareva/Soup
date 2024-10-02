namespace Assets.Scripts.Core.Entities
{
    public class User
    {
        public int Money { get; private set; }

        public User(int money)
        {
            Money = money;
        }
        public void AddMoney(int money)
        {
            Money += money;
        }

        public void RemoveMoney(int money)
        {
            Money -= money;
        }
    }
}