using R3;
using Repositories.Configs;

namespace Domain.Models
{
    /// <summary>
    /// Игровая модель, хранящая в себе состояние игрока.
    /// </summary>
    public class HeroModel
    {
        public ReactiveProperty<int> Level { get; } = new();
        public ReactiveProperty<int> Damage { get; } = new();
        public ReactiveProperty<int> Health { get; } = new();

        private readonly HeroData _config;

        public HeroModel(HeroData config)
        {
            _config = config;
            ResetToBaseStats();
        }

        public void ResetToBaseStats()
        {
            Level.Value = _config.BaseLevel;
            Damage.Value = _config.BaseDamage;
            Health.Value = _config.BaseHealth;
        }

        public void Upgrade()
        {
            Level.Value += _config.LevelIncrement;
            Damage.Value += _config.DamageIncrement;
            Health.Value += _config.HealthIncrement;
        }
    } 
}
