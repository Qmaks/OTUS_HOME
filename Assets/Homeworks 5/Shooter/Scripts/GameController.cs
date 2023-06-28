using System;
using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Common;
using UnityEngine;
using Zenject;

public class GameController: IInitializable,IDisposable
{
    [Inject] private HeroEntity heroEntity;
    [Inject] private FinishGameView finishGameView;
    
    public void Initialize()
    {
        heroEntity.Get<IDeathComponent>().OnDeath += OnDeath;
    }

    private void OnDeath(Entity entity)
    {
        finishGameView.Show();
        Time.timeScale = 0;
    }

    public void Dispose()
    {
        heroEntity.Get<IDeathComponent>().OnDeath -= OnDeath;
    }
}
