using System;
using Application.UseCases;
using Domain.Models;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation.Presenters
{
    public sealed class HeroPresenter : IDisposable
    {
        private readonly HeroModel _hero;
        private readonly VisualElement _root;
        private readonly CompositeDisposable _disposables = new();

        public HeroPresenter(UIDocument uiDocument, HeroModel hero, UpgradeHeroUsecase useCase)
        {
            Debug.Log($"Presenter started. UIDoc: {uiDocument != null}");
            Debug.Log($"HeroModel: {_hero != null}");
            Debug.Log($"UseCase: {useCase != null}");
            
            _hero = hero;
            _root = uiDocument.rootVisualElement;
            
            var root = uiDocument.rootVisualElement;
            Debug.Log($"Root element: {root != null}");
            
            _hero.Level.Subscribe(l => _root.Q<Label>("levelLabel").text = $"Level: {l}").AddTo(_disposables);
            _hero.Damage.Subscribe(d => _root.Q<Label>("damageLabel").text = $"Damage: {d}").AddTo(_disposables);
            _hero.Health.Subscribe(h => _root.Q<Label>("healthLabel").text = $"Health: {h}").AddTo(_disposables);
            
            _root.Q<Button>("upgradeButton").clickable.clicked += useCase.Execute;
        }
        
        
        public void Dispose() => _disposables.Dispose();
    }
}