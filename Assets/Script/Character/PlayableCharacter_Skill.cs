using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter_Skill : FSMSingleton<PlayableCharacter_Skill>, IFSMState<PlayableCharacter>
{
    
    public void Enter(PlayableCharacter e)
    {
        e.nav.isStopped = false;
       
    }
    public void Execute(PlayableCharacter e)
    {
    

        if(Vector3.Distance(e.transform.position,e.ReservedSkillPos.position)>e.ReservedSkill.SkillDist)
        {

           // e.move(e.ReservedSkillPos);
        }
        else
        {
            e.nav.isStopped = true;
           // e.move(e.transform);
             e.ChangeState(PlayableCharacter_Idle._Inst);
        }
       


    }

    public void Exit(PlayableCharacter e)
    {

    }
}
