using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterDeathSystem : MonoBehaviour
    {
        [Inject] private GameManager gameManager;
        [Inject] private CharacterView characterView;
        
        private void OnEnable()
        {
            characterView.HitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            characterView.HitPointsComponent.HpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}