using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Component;
using UnityEngine;
using Zenject;

public class LookAtController : ITickable
{
    [Inject] private HeroEntity hero;
    
    private LayerMask groundMask = LayerMask.GetMask("Ground");
    
    public void Tick()
    {
        var lookAtComponent = hero.Get<ILookAtComponent>();
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            lookAtComponent.LookAt(new Vector3(hitInfo.point.x, hero.transform.position.y, hitInfo.point.z));
        }
    }
}
