using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Bullet.Components
{
    interface IGetDamageComponent
    {
        int GetDamage();
    }
    
    public class GetDamageComponent : IGetDamageComponent
    {
        private AtomicVariable<int> damage;

        public GetDamageComponent(AtomicVariable<int> damage)
        {
            this.damage = damage;
        }

        public int GetDamage() => damage.Value;
    }
}