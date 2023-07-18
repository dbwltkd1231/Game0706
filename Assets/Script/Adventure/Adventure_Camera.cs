using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventure_Camera : MonoBehaviour
{
    [Header("카메라 위치 좌표"), SerializeField]
    Vector3 CameraPos;
    [SerializeField]
    GameObject Target;

    void init()
    {
        Target = Player.Instance.PlayabeCharacterList[0].gameObject;
    }
    private void FixedUpdate()
    {
        if(Target!=null)
        {
            transform.LookAt(Target.transform);
            transform.position = Target.transform.position + CameraPos;
        }
    
    }


}
