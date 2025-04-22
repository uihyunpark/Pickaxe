using System;
using UnityEngine;

public static class SkillFactory
{
    public static ISkillBehavior GetBehavior(PlayerSkillSO playerSkill)
    {
        return playerSkill.skillType switch
        {
            SkillType.Single => new SingleAttackSkill(playerSkill),
            //SkillType.AoE => new AoESkill(),
            //SkillType.Buff => new BuffSkill(),
            //SkillType.Agile => new AgileSkill(),
            //SkillType.Tick => new TickSkill(),
            //SkillType.Passive => new PassiveSkill(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

}
