namespace WarriorsLib;

public interface IAttackGenerator
{
    void Clear();
    void Setup(int percentageChance, AttackHow attackHow);
    AttackHow GenerateAtack();
}