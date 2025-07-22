using System;
using Application.UseCases;
using Domain.Models;
using R3;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace Presentation.Presenters
{
    public sealed class HeroPresenter : IStartable, IDisposable
    {
        private readonly UIDocument _uiDocument;
        private readonly UpgradeHeroUsecase _useCase;
        private readonly HeroModel _hero;
        private VisualElement _root;
        private readonly CompositeDisposable _disposables = new();

        public HeroPresenter(
            UIDocument uiDocument,
            HeroModel hero,
            UpgradeHeroUsecase useCase)
        {
            _uiDocument = uiDocument;
            _hero = hero;
            _useCase = useCase;
        }

        public void Start()
        {
            _root = _uiDocument.rootVisualElement;

            var levelLabel = _root.Q<Label>("levelLabel");
            var damageLabel = _root.Q<Label>("damageLabel");
            var healthLabel = _root.Q<Label>("healthLabel");
            var button = _root.Q<Button>("upgradeButton");

            _hero.Level.Subscribe(l => levelLabel.text = $"Level: {l}").AddTo(_disposables);
            _hero.Damage.Subscribe(d => damageLabel.text = $"Damage: {d}").AddTo(_disposables);
            _hero.Health.Subscribe(h => healthLabel.text = $"Health: {h}").AddTo(_disposables);
            
            button.clickable.clicked += _useCase.Execute;
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
