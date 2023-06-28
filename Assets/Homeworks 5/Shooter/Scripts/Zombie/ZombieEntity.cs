using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Common;
using Homeworks_5.Shooter.Scripts.Zombie.Component;
using UnityEngine;

public class ZombieEntity : Entity
{
   [SerializeField] 
   public ZombieModel model;
   
   private void Awake()
   {
      Add(new TargetComponent(model.core.target));
      Add(new TakeDamageComponent(model.core.life.onTakeDamage));
      Add(new DeathComponent(this,model.core.life.isDeath));
   }
}
