using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsLib;

public abstract class Damage
{
    private decimal _amount;

    public Damage(decimal amount)
    {
        _amount = amount;
    }

    public virtual decimal Amount => _amount;
}
