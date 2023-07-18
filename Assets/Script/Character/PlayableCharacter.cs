using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayableCharacter : FSM<PlayableCharacter>
{
    [Header("공격 딜레이"), SerializeField]
    public float AttackDelay;
    [Header("공격 사거리"), SerializeField]
    public float AttackDist;
    [Header("진영 좌표"), SerializeField]
    Vector3 myPos;
    [Header("스킬 리스트"), SerializeField]
    Skill[] skills;//임시용
    [Header("자동 적탐색 시간"), SerializeField]
    public float AutoFind = 3f;

    public Transform Target;
    public Transform ReservedSkillPos;
    public Skill ReservedSkill;

   public  NavMeshAgent nav;
    Character ConnectedCharacter;
    List<Skill> mySKills;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        mySKills = new List<Skill>();
        InitState(this, PlayableCharacter_Idle._Inst);

    }
    void Update()
    {

        FSMUpdate();
        
        if (Input.GetMouseButtonDown(0) && AdventureManager.Instance.Skilling == false)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))//레이케스트(마우스 클릭위치,레이케스트가 맞은곳,무한대기)
                {
                    Target = hit.transform;

                    if (hit.collider.tag == "Ground")
                    {

                        move(hit.transform);
                        ChangeState(PlayableCharacter_Move._Inst);

                    }
                    else if (hit.collider.tag == "Enemy")
                    {
                        ChangeState(PlayableCharacter_Chase._Inst);
                        
                        Debug.Log("오브젝트에 맞음");
                    }
                    else
                    {

                    }
                }
            }

        }

    }
    public void move(Transform pos)
    {
        Vector3 Goal = Target.position + myPos;
        nav.SetDestination(Goal);
    
    }
    public void move(Transform pos,Skill skill)
    {
        
        ChangeState(PlayableCharacter_Skill._Inst);
        ReservedSkill = skill;
        ReservedSkillPos = pos;
        nav.SetDestination(pos.position);
    }
    public void Connected(Character character)
    {
        ConnectedCharacter = character;
        for(int i=0;i<ConnectedCharacter.skills.Length;i++)
        {
            mySKills.Add(ConnectedCharacter.skills[i]);
        }
    }
}
