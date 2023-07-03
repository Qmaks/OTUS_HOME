using Declarative;
using Homeworks_5.Shooter.Scripts;
using UnityEngine;

public class HeroModel : DeclarativeModel
{
    [Section]
    [SerializeField]
    public HeroModel_Core core = new();

    [Section]
    [SerializeField]
    public HeroModel_View view = new();    
}
