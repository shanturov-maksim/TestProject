using Domain.Models;

namespace Application.UseCases
{
    public sealed class UpgradeHeroUsecase
    {
        private readonly HeroModel _hero;

        public UpgradeHeroUsecase(HeroModel hero)
        {
            _hero = hero;
        }

        public void Execute()
        {
            _hero.Upgrade();
        }
    }
}
