using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public float speed;

    Vector2 inputvec;


    public List<PlayerSkillSO> skillDatas;
    private List<Skill> skills;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        skills = new List<Skill>();
        foreach (var data in skillDatas)
            skills.Add(new Skill(data));
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, inputvec, speed);

    }
    private void FixedUpdate()
    {
    }

    public void OnMove()
    {
        inputvec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    void TryUseSkill(int index)
    {
        if (index < 0 || index >= skills.Count) return;

        var skill = skills[index];

        object target = GetSkillTarget(skill.data);
        Debug.Log("Target: " + target + "skill = " + skill.data.definition);
        skill.Use(transform, target);
    }

    object GetSkillTarget(PlayerSkillSO data)
    {
        switch (data.skillType)
        {
            case SkillType.Single:
                return FindClosestMonster(data.distance); // 단일 몬스터
            case SkillType.AoE:
                return FindMonstersInRange(data.distance); // 몬스터 리스트
            case SkillType.Buff:
                return this; // 자기 자신
            case SkillType.Agile:
                return transform; // 위치 정보
            default:
                return null;
        }
    }

    private Collider2D[] FindMonstersInRange(float distance)
    {
        Collider2D[] mons = Physics2D.OverlapCircleAll(transform.position, distance, LayerMask.GetMask("Monster"));

        return mons;
    }

    private object FindClosestMonster(float distance)
    {
        // Find the closest monster within the specified distance
        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, distance, LayerMask.GetMask("Monster"));
        Debug.Log(monsters);
        if (monsters.Length == 0) return null;
        // Sort the monsters by distance
        Array.Sort(monsters, (a, b) =>
        {
            float distA = Vector2.Distance(transform.position, a.transform.position);
            float distB = Vector2.Distance(transform.position, b.transform.position);
            return distA.CompareTo(distB);
        });
        // Return the closest monster
        return monsters[0];

    }

    public void OnQskill()
    {
        TryUseSkill(0);

    }
    public void OnWskill()
    {
        TryUseSkill(1);

    }
    public void OnEskill()
    {
        TryUseSkill(2);

    }
    public void OnRskill()
    {
        TryUseSkill(3);

    }


}
