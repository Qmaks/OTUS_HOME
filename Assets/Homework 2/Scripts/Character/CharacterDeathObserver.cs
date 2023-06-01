using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterDeathObserver : IInitializable , IDisposable
    {
        [Inject] private GameManager gameManager;
        [Inject] private CharacterView characterView;

        public void Initialize()
        {
            characterView.HitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        public void Dispose()
        {
            characterView.HitPointsComponent.HpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}