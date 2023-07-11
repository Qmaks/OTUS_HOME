using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Common;
using Homeworks_5.Shooter.Scripts.Component;
using Homeworks_5.Shooter.Scripts.Zombie.Component;
using UnityEngine;

public class ZombieEntity : Entity
{
   [SerializeField] 
   public ZombieModel model;
   
   private void Awake()
   {
      Add(new TargetComponent(model.core.target));
      Add(new TakeDamageComponent(model.core.lifeSection.onTakeDamage));
      //Add(new DeathTimerComponent(this,model.view.delayDeathAnimation));
      Add(new DeathComponent(this,model.core.lifeSection.isDeath));
      Add(new TransformComponent(transform));
   }
}
