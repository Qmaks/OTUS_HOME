using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Component;
using UnityEngine;
using Zenject;

public class MoveController : ITickable
{
    [Inject] private HeroEntity hero;

    public void Tick()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        
        hero.Get<IMoveInDirectionComponent>().Move(direction.normalized);
    }
}
