using Zenject;

namespace ShootEmUp
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyAttackAgent>().FromComponentsInHierarchy().AsSingle();
        }
    }
}