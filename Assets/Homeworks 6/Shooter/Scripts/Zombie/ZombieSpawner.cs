using System;
using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Component;
using Homeworks_5.Shooter.Scripts.Zombie;
using Homeworks_5.Shooter.Scripts.Zombie.Component;
using Lessons.Gameplay;
using Zenject;

public class ZombieSpawner : IInitializable
{
    public Action<ZombieEntity> OnZombieSpawn;
    
    [Inject] private HeroEntity heroEntity;
    [Inject] private SpawnPointsController spawnPointsController;
    [Inject] private ZombieFactory factory;

    private RepeatTimerMechanics repeatTimer = new();

    public void Initialize()
    {
        repeatTimer.Duration = 2f;
        repeatTimer.OnCompleted += Spawn;
        repeatTimer.Play();
    }

    private void Spawn()
    {
        var point = spawnPointsController.GetRandomSpawnPoint();
        var zombie = factory.Create();
        zombie.Get<IPositionComponent>().Position = point.position;
        zombie.Get<ITargetComponent>().SetTarget(heroEntity);
        
        OnZombieSpawn?.Invoke(zombie);
    }
}