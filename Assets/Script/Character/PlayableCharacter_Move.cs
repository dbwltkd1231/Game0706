using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayableCharacter_Move : FSMSingleton<PlayableCharacter_Move>, IFSMState<PlayableCharacter>
{
    public void Enter(PlayableCharacter e)
    {
        e.nav.isStopped = false;
    }
    public void Execute(PlayableCharacter e)
    {
       
        //e.move(e.Target);
        Debug.Log(Vector3.Distance(e.transform.position, e.Target.transform.position));
       if(Vector3.Distance(e.transform.position,e.Target.transform.position)<2.33f)
        {
            e.ChangeState(PlayableCharacter_Idle._Inst);
        }


    }

    public void Exit(PlayableCharacter e)
    {

    }
}


