using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;

public class PlayableCharacter_Idle : FSMSingleton<PlayableCharacter_Idle>, IFSMState<PlayableCharacter>
{
    float time = 0;
    Vector3 attackArea;
    Collider[] myArea;
    public void Enter(PlayableCharacter e)
    {
        e.nav.isStopped = true;
        attackArea = new Vector3(7,7,7);
    }
    public void Execute(PlayableCharacter e)
    {
        time += Time.deltaTime;
        if(time>e.AutoFind)
        {
            myArea=Physics.OverlapBox(e.transform.position, attackArea);
            for(int i=0;i< myArea.Length;i++)
            {
                if (myArea[i].CompareTag("Enemy"))
                {
                    e.Target = myArea[i].gameObject.transform;
                    e.ChangeState(PlayableCharacter_Attack._Inst);
                    time = 0;
                }
            }
            
        }

    }

    public void Exit(PlayableCharacter e)
    {
       
    }

}
