using System.Reflection.Emit;

namespace WarriorsLib;

public class MeleeWarrior : Warrior
{
    public MeleeWarrior(IAttackGenerator generator) : base(generator)
    {
        
    }

    public override void Attack(Warrior opponent, AttackRange range)
    {
        if(range == AttackRange.Melee)
        {
            _attackGenerator.Clear();
            // 80% chance of attacking with melee
            _attackGenerator.Setup(80, AttackHow.AttackWithMelee);
            // 10% chance of attacking with magic
            _attackGenerator.Setup(10, AttackHow.AttackWithMagic);
            // 10% chance of missing
            _attackGenerator.Setup(10, AttackHow.Miss);
            AttackHow attackHow = _attackGenerator.GenerateAtack();
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