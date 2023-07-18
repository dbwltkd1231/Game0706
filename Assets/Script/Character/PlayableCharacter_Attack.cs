using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayableCharacter_Attack : FSMSingleton<PlayableCharacter_Attack>, IFSMState<PlayableCharacter>
{
    float time;
    public void Enter(PlayableCharacter e)
    {
        e.nav.isStopped = false;
        time = 0;
    }
    public void Execute(PlayableCharacter e)
    {
        if (Vector3.Distance(e.Target.transform.position, e.transform.position) < e.AttackDist)
        {
            e.nav.isStopped = true;
            time += Time.deltaTime;
            if (e.AttackDelay > time)
            {
                e.transform.LookAt(e.Target);
                time = 0;
                Debug.Log("������");
            }
           
        }
        else
        {
            e.move(e.Target);
        }
      
      
        /*
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))//�����ɽ�Ʈ(���콺 Ŭ����ġ,�����ɽ�Ʈ�� ������,���Ѵ��)
                {
                    if (hit.collider.tag == "Ground")
                    {

                        e.Target = hit.transform;
                        e.ChangeState(PlayableCharacter_Move._Inst);

                    }
                    else if (hit.collider.tag == "Enemy")
                    {
                        if (Vector3.Distance(hit.transform.position, transform.position) < e.AttackDist)
                        {

                        }
                        else
                        {
                            e.Target = hit.transform;
                            e.ChangeState(PlayableCharacter_Chase._Inst);
                        }
                        Debug.Log("������Ʈ�� ����");
                    }
                    else
                    {

                    }
                }
            }

        }
        */
    }

    public void Exit(PlayableCharacter e)
    {

    }
}
