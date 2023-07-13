using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayableCharacter : MonoBehaviour
{
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//마우스 클릭이 됬다면
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))//레이케스트(마우스 클릭위치,레이케스트가 맞은곳,무한대기)
            {
                if (hit.collider.tag == "Ground")
                {
                    move(hit.transform);//플레이어의 위치를 레이케스트가 맞은곳으로 이동  
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("오브젝트에 맞음");
                }
                else
                {

                }
            }
        }
    }
    void move(Transform pos)
    {
        nav.SetDestination(pos.position);
    }
}
