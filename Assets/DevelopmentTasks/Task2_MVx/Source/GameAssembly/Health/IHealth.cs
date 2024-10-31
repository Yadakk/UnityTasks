namespace MVxTask.Health
{
    public interface IHealth
    {
        public event System.Action OnHealthChanged;
        public event System.Action OnHealthDepleted;

        public float MaxHealth { get; }
        public float CurrentHealth { get; set; }
    }
}
