using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class SkillSlot : MonoBehaviour,IPointerClickHandler, IDragHandler
{
    [SerializeField]
    PlayableCharacter myharacter;
    [SerializeField]
    Skill mySkill;

    bool SkillIng;
    public void OnPointerClick(PointerEventData eventData)
    {
        AdventureManager.Instance.Skill_init(myharacter, mySkill);
       AdventureManager.Instance.Skilling = true;
    }
 
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
       
       
    }
}
