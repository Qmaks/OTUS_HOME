using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterDeathSystem : IInitializable
    {
        [Inject] private GameManager gameManager;
        [Inject] private CharacterView characterView;

        public void Initialize()
        {
            characterView.HitPointsComponent.HpEmpty += OnCharacterDeath;
        }
        
        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}