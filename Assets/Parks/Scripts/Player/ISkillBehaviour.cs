using UnityEngine;

public interface ISkillBehavior
{
    void Execute(Transform caster, object target, PlayerSkillSO data);
}
