using Application.UseCases;
using Domain.Models;
using Presentation.Presenters;
using Repositories.Configs;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    /// <summary>
    /// Основной DI инсталлер
    /// </summary>
    public class Installer : LifetimeScope
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private HeroData _heroConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_heroConfig);
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<UpgradeHeroUsecase>(Lifetime.Singleton);
            builder.RegisterInstance(_uiDocument);
            builder.RegisterEntryPoint<HeroPresenter>();
        }
    }
}