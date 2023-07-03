using System;
using Homeworks_5.Shooter.Scripts.Zombie;
using Zenject;

namespace Homeworks_5.Shooter.Scripts.UI
{
    public class KilledViewPresenter :  IInitializable,IDisposable
    {
        [Inject(Id = typeof(KilledViewPresenter))]
        private TextView textView;
        
        [Inject]
        private ZombieDestroyer zombieDestroyer;
        
        public void Initialize()
        {
            zombieDestroyer.ZombieDestroyed.OnChanged += UpdateView;
            UpdateView(0);
        }

        private void UpdateView(int killed)
        {
            textView.SetText($"KILLS: {killed}");
        }

        public void Dispose()
        {
            zombieDestroyer.ZombieDestroyed.OnChanged -= UpdateView;
        }
    }
}