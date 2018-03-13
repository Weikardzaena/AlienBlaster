using System;

public class DOTApplier
{
    public float Period { get; private set; }
    public UInt32 Damage { get; private set; }

    public DamageableComp Target { get; private set; }

    private float mNextFireTime = 0.0f;

    public DOTApplier(float period, UInt32 damage, DamageableComp target)
    {
        Period = period;
        Damage = damage;
        Target = target;
    }

    public void Update(float deltaTime)
    {
        mNextFireTime -= deltaTime;

        if ((mNextFireTime < 0.0f) && Target) {
            mNextFireTime = Period;
            Target.DealDamage(Damage);
        }
    }
}
