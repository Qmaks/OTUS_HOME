using System;
using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Component;
using Homeworks_5.Shooter.Scripts.UI;
using Zenject;

public class BulletViewPresenter : IInitializable,IDisposable
{
    [Inject(Id = typeof(BulletViewPresenter))]
    private TextView textView;
    
    [Inject]
    private HeroEntity heroEntity;
    
    private IAmmoComponent ammoComponent;

    public void Initialize()
    {
        ammoComponent = heroEntity.Get<IAmmoComponent>();
        ammoComponent.OnUpdateAmmo += UpdateAmmo;
        
        UpdateAmmo(ammoComponent.GetCurrentAmmo());
    }

    private void UpdateAmmo(int count)
    {
        textView.SetText($"Bullets: {count}/{ammoComponent.GetMaxAmmo()}");
    }

    public void Dispose()
    {
        heroEntity.Get<IAmmoComponent>().OnUpdateAmmo -= UpdateAmmo;        
    }
}
