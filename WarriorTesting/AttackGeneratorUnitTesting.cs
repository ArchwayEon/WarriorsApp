using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsLib;

namespace WarriorTesting;

internal class AnAttackGenerator
{
    [Test]
    public void CanSetupAttacks()
    {
        var mockGenerator = new Mock<IRandomGenerator>();
        var sut = new AttackGenerator(mockGenerator.Object);
        sut.Setup(80, AttackHow.AttackWithMelee);
        sut.Setup(10, AttackHow.AttackWithMagic);
        sut.Setup(10, AttackHow.Miss);
        mockGenerator.SetupSequence(g => g.RollDice(100))
            .Returns(80)
            .Returns(90)
            .Returns(100);
        Assert.That(sut.GenerateAtack(), Is.EqualTo(AttackHow.AttackWithMelee));
        Assert.That(sut.GenerateAtack(), Is.EqualTo(AttackHow.AttackWithMagic));
        Assert.That(sut.GenerateAtack(), Is.EqualTo(AttackHow.Miss));
    }
}
