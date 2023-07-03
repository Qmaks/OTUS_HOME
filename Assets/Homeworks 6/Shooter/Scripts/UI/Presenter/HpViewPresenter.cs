using System;
using Homeworks_5.Shooter.Scripts.Component;
using Zenject;

namespace Homeworks_5.Shooter.Scripts.UI
{
    public class HpViewPresenter : IInitializable, IDisposable
    {
        [Inject(Id = typeof(HpViewPresenter))]
        private TextView textView;
    
        [Inject]
        private HeroEntity heroEntity;
        
        public void Initialize()
        {
            var healthComponent = heroEntity.Get<IHealthComponent>();
            healthComponent.OnHealthChange += UpdateView;
            
            UpdateView(healthComponent.GetHp());
        }

        private void UpdateView(int hp)
        {
            textView.SetText($"HEALTH: {hp}");
        }

        public void Dispose()
        {
            heroEntity.Get<IHealthComponent>().OnHealthChange -= UpdateView;
        }
    }
}