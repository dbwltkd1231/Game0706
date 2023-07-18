using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{

    [Header("마우스 프리팹"), SerializeField]
    GameObject MousePrefab;
    [Header("마우스 마법진 추가좌표"), SerializeField]
    Vector3 MousePos;

    public static AdventureManager Instance;


    public bool Skilling;
    RaycastHit hit;
    GameObject Prefab;
    PlayableCharacter SelectedCharacter;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        Skilling = false;
        Prefab = Instantiate(MousePrefab);
        Prefab.SetActive(false);
    }

    
    void Update()
    {
        if(Skilling==true)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Ground")
                {
                  
                    Prefab.transform.position = hit.point + MousePos;
                    if(Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SelectedCharacter.move(hit.transform,SelectedCharacter.ReservedSkill);
                        Prefab.SetActive(false);
                        StartCoroutine(ClickDelay());
                    }

                }

            }
        }
    }

    public void Skill_init(PlayableCharacter character, Skill skill)
    {

        SelectedCharacter = character;
        SelectedCharacter.ReservedSkill = skill;
        
        Prefab.SetActive(true);

    }

    IEnumerator ClickDelay()
    {
        yield return new WaitForSeconds(1f);
        Skilling = false;
        yield return null;
    }
}
