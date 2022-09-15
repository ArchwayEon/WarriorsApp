namespace WarriorsLib;

public interface IAttackGenerator
{
    void Setup(int percentageChance, AttackHow attackHow);
    AttackHow GenerateAtack();
}