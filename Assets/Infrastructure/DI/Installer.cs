using Application.UseCases;
using Domain.Models;
using Presentation.Presenters;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class Installer : LifetimeScope
{
    [SerializeField] private UIDocument _uiDocument;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<HeroModel>(Lifetime.Singleton);
        builder.Register<UpgradeHeroUsecase>(Lifetime.Singleton);
        builder.RegisterInstance(_uiDocument);
        builder.RegisterEntryPoint<HeroPresenter>();
    }
}