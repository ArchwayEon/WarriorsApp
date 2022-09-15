namespace WarriorsLib;

public abstract class Warrior
{
    public decimal HitPoints { get; private set; }
    public decimal MeleePower { get; private set; }
    public decimal MagicPower { get; private set; }
    public int DefensePercentage { get; private set; }

    protected IAttackGenerator _attackGenerator;

    public Warrior(IAttackGenerator generator)
    {
        _attackGenerator = generator;
    }

    public abstract void Attack(Warrior warrior, AttackRange range);

    public virtual void TakeDamage(Damage damage)
    {
        HitPoints -= damage.Amount;
    }

}