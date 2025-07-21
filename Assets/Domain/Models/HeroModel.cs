using R3;

namespace Domain.Models
{
    public class HeroModel
    {
        public ReactiveProperty<int> Level { get; } = new(1);
        public ReactiveProperty<int> Damage { get; } = new(10);
        public ReactiveProperty<int> Health { get; } = new(100);

        public void Upgrade()
        {
            Level.Value++;
            Damage.Value += 5;
            Health.Value += 20;
        }
    } 
}
