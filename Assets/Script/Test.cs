using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    GameObject tmp;

    // Update is called once per frame
    void Update()
    {
        if(tmp!=null)
        {
            transform.LookAt(tmp.transform);
        }
    }
}
