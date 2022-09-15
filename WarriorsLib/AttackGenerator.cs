using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsLib;

public class AttackGenerator : IAttackGenerator
{
    private Dictionary<AttackHow, int> _attackChances = new();
    private readonly IRandomGenerator _generator;

    public AttackGenerator(IRandomGenerator generator)
    {
        _generator = generator;
    }

    public AttackHow GenerateAtack()
    {
        int roll = _generator.RollDice(100);
        bool firstTime = true;
        int value = 0;
        AttackHow attack = AttackHow.Miss;
        foreach(var attackHowKVP in _attackChances)
        {
            if (firstTime)
            {
                value = attackHowKVP.Value;
                firstTime = false;
            }
            else
            {
                value += attackHowKVP.Value;
            }

            if(roll <= value)
            {
                attack = attackHowKVP.Key;
                break;
            }
        }
        return attack;
    }

    public void Setup(int percentageChance, AttackHow attackHow)
    {
        _attackChances.Add(attackHow, percentageChance);
    }
}
