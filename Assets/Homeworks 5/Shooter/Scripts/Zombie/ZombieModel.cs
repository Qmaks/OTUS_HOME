using Declarative;
using Homeworks_5.Shooter.Scripts.Zombie;
using UnityEngine;

public class ZombieModel : DeclarativeModel
{
    [Section]
    [SerializeField]
    public ZombieModelCore core = new();
    
    [Section]
    [SerializeField]
    public ZombieModelView view = new();
}