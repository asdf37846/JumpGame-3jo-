using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject A;  //A��� GameObject���� ����
    Transform AT;
    void Start()
    {
        AT = A.transform;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }
}
