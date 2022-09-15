namespace WarriorsLib;

public class MeleeWarrior : Warrior
{
    public MeleeWarrior(IAttackGenerator generator) : base(generator)
    {
        // 80% chance of attacking with melee
        generator.Setup(80, AttackHow.AttackWithMelee);
        // 10% chance of attacking with magic
        generator.Setup(10, AttackHow.AttackWithMagic);
        // 10% chance of missing
        generator.Setup(10, AttackHow.Miss);
    }

    public override void Attack(Warrior opponent, AttackRange range)
    {
        if(range == AttackRange.Melee)
        {
            AttackHow attackHow = _generator.GenerateAtack();
            Damage damage;
            switch (attackHow)
            {
                case AttackHow.AttackWithMelee:
                    damage = new MeleeDamage(MeleePower - (opponent.DefensePercentage * MeleePower));
                    opponent.TakeDamage(damage);
                    break;
                case AttackHow.AttackWithMagic:
                    damage = new MagicDamage(MagicPower - (opponent.DefensePercentage * MagicPower));
                    opponent.TakeDamage(damage);
                    break;
                case AttackHow.Miss:
                    break;
            }
         
        }
    }
}