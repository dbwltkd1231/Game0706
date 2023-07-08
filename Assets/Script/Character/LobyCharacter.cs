using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LobyCharacter : MonoBehaviour, IPointerClickHandler
{
    public int ID;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Player.Instance.LobySeletCharacter(this);
        int randomvalue = Random.Range(0, 4);
        if(randomvalue==0)
        {
            anim.SetTrigger("Idle1");
        }
        else if (randomvalue == 1)
        {
            anim.SetTrigger("Idle2");
        }
        else if (randomvalue == 2)
        {
            anim.SetTrigger("Idle3");
        }
        else if (randomvalue == 3)
        {
            anim.SetTrigger("Idle4");
        }
        

    }

}
