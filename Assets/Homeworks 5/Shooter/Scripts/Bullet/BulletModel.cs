using Declarative;
using Homeworks_5.Shooter.Scripts.Bullet.Core;
using UnityEngine;

public class BulletModel : DeclarativeModel
{
    [Section]
    [SerializeField]
    public BulletModel_Core core = new();
    
    
    [Construct]
    public void Construct()
    {
        StartCoroutine(core.lifeTimer.Play());
    }
}
