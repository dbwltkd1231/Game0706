using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayableCharacter : FSM<PlayableCharacter>
{
    [Header("���� ������"), SerializeField]
    public float AttackDelay;
    [Header("���� ��Ÿ�"), SerializeField]
    public float AttackDist;
    [Header("���� ��ǥ"), SerializeField]
    Vector3 myPos;
    [Header("��ų ����Ʈ"), SerializeField]
    Skill[] skills;//�ӽÿ�
    [Header("�ڵ� ��Ž�� �ð�"), SerializeField]
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
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))//�����ɽ�Ʈ(���콺 Ŭ����ġ,�����ɽ�Ʈ�� ������,���Ѵ��)
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
                        
                        Debug.Log("������Ʈ�� ����");
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
