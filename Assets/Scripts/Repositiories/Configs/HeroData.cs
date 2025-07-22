using UnityEngine;

namespace Repositories.Configs
{
    /// <summary>
    /// Настройки базовых значений игрока и значений улучшения его характеристик.
    /// </summary>
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "HeroConfig")]
    public class HeroData : ScriptableObject
    {
        [field: SerializeField] public int BaseLevel { get; private set; }
        [field: SerializeField] public int BaseDamage{ get; private set; }
        [field: SerializeField] public int BaseHealth{ get; private set; }

        [field: SerializeField] public int LevelIncrement { get; private set; }
        [field: SerializeField] public int DamageIncrement { get; private set; }
        [field: SerializeField] public int HealthIncrement { get; private set; }
    }   
}
