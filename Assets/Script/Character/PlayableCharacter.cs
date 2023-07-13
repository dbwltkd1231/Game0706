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
        if (Input.GetMouseButtonDown(0))//���콺 Ŭ���� ��ٸ�
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))//�����ɽ�Ʈ(���콺 Ŭ����ġ,�����ɽ�Ʈ�� ������,���Ѵ��)
            {
                if (hit.collider.tag == "Ground")
                {
                    move(hit.transform);//�÷��̾��� ��ġ�� �����ɽ�Ʈ�� ���������� �̵�  
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("������Ʈ�� ����");
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
