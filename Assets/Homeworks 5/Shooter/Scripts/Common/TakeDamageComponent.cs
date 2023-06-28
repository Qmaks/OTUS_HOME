using Lessons.Gameplay;


public interface ITakeDamageComponent
{
    void ReceiveDamage(int damage);
}

public class TakeDamageComponent : ITakeDamageComponent
{
    private  AtomicEvent<int> onTakeDamage;

    public TakeDamageComponent(AtomicEvent<int> onTakeDamage)
    {
        this.onTakeDamage = onTakeDamage;
    }

    public void ReceiveDamage(int damage)
    {
        onTakeDamage.Invoke(damage);
    }
}