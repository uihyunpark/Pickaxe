using UnityEngine;

public class Skill
{
    public PlayerSkillSO data;
    private ISkillBehavior behavior;

    public Skill(PlayerSkillSO data)
    {
        this.data = data;
        this.behavior = SkillFactory.GetBehavior(data);
        Debug.Log("Skill created: " + data.skillName);
    }

    public void Use(Transform caster, object target)
    {
        behavior.Execute(caster, target, data);
    }
}