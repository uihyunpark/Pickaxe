#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerSkillSO))]
public class MyCustom : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        PlayerSkillSO skill = (PlayerSkillSO)target;

        EditorGUILayout.LabelField("�� �⺻ ����", EditorStyles.boldLabel);
        skill.skillIndex = EditorGUILayout.IntField("Skill Index", skill.skillIndex);
        skill.skillName = EditorGUILayout.TextField("Skill Name", skill.skillName);
        skill.definition = EditorGUILayout.TextField("Definition", skill.definition);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�� ��ų �Ӽ�", EditorStyles.boldLabel);
        skill.skillType = (SkillType)EditorGUILayout.EnumFlagsField("Skill Type", skill.skillType);
        skill.damage = EditorGUILayout.FloatField("Damage", skill.damage);
        skill.ratio = EditorGUILayout.FloatField("Ratio", skill.ratio);
        skill.distance = EditorGUILayout.FloatField("Distance", skill.distance);
        skill.angle = EditorGUILayout.FloatField("Angle", skill.angle);
        skill.duration = EditorGUILayout.FloatField("Duration", skill.duration);
        skill.coolTime = EditorGUILayout.FloatField("Cool Time", skill.coolTime);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�� Ÿ�� ���� (����)", EditorStyles.boldLabel);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(skill);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif