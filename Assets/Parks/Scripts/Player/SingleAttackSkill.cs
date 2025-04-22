using UnityEngine;

internal class SingleAttackSkill : ISkillBehavior
{
    private readonly PlayerSkillSO data;
    public SingleAttackSkill(PlayerSkillSO data) => this.data = data;

    public void Execute(Transform caster, object target, PlayerSkillSO data)
    {
        Monster monster = target as Monster;
        if (monster == null) return;

        float damage = data.damage * data.ratio;
        monster.TakeDamage(damage);
    }
}