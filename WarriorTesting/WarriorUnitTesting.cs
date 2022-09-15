using Moq;
using WarriorsLib;

namespace WarriorTesting;

public class AMeleeWarrior
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CanAttackWithMeleeWhenInMeleeRange()
    {
        var mockGenerator = new Mock<IAttackGenerator>();
        mockGenerator.Setup(g => g.GenerateAtack()).Returns(AttackHow.AttackWithMelee);
        var mockOpponent = new Mock<Warrior>(mockGenerator.Object);
        MeleeWarrior sut = new(mockGenerator.Object);
        sut.Attack(mockOpponent.Object, AttackRange.Melee);
        mockOpponent.Verify(w => w.TakeDamage(It.IsAny<MeleeDamage>()));
    }

    [Test]
    public void CanAttackWithMagicWhenInMeleeRange()
    {
        var mockGenerator = new Mock<IAttackGenerator>();
        mockGenerator.Setup(g => g.GenerateAtack()).Returns(AttackHow.AttackWithMagic);
        var mockOpponent = new Mock<Warrior>(mockGenerator.Object);
        MeleeWarrior sut = new(mockGenerator.Object);
        sut.Attack(mockOpponent.Object, AttackRange.Melee);
        mockOpponent.Verify(w => w.TakeDamage(It.IsAny<MagicDamage>()));
    }

    [Test]
    public void CanMissWhenInMeleeRange()
    {
        var mockGenerator = new Mock<IAttackGenerator>();
        mockGenerator.Setup(g => g.GenerateAtack()).Returns(AttackHow.Miss);
        var mockOpponent = new Mock<Warrior>(mockGenerator.Object);
        MeleeWarrior sut = new(mockGenerator.Object);
        sut.Attack(mockOpponent.Object, AttackRange.Melee);
        mockOpponent.Verify(w => w.TakeDamage(It.IsAny<Damage>()), Times.Never);
    }
}