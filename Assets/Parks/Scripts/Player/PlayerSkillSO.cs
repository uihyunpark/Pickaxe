using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkillSO", menuName = "Scriptable Objects/PlayerSkillSO")]
public class PlayerSkillSO : ScriptableObject
{
    public int skillIndex;
    public string skillName;
    public SkillType skillType;
    public float damage;
    public float ratio;
    public float distance;
    public float angle;
    public float duration;
    public float coolTime;
    [TextArea] public string definition;
}
public enum SkillType
{
    Single,
    AoE,
    Buff,
    Agile,
    Tick,
    Passive
}