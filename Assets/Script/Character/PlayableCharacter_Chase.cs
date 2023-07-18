using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter_Chase : FSMSingleton<PlayableCharacter_Chase>, IFSMState<PlayableCharacter>
{
    public void Enter(PlayableCharacter e)
    {
        e.nav.isStopped = false;
    }
    public void Execute(PlayableCharacter e)
    {
        if(Vector3.Distance(e.transform.position,e.Target.position)<e.AttackDist)
        {
            e.ChangeState(PlayableCharacter_Attack._Inst);
        }
        else
        {
            e.move(e.Target);
        }

    }

    public void Exit(PlayableCharacter e)
    {

    }
}

