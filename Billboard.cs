using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    public GameObject cam;

    void Update()
    {
        transform.LookAt(cam.transform.position, -Vector3.forward);   
    }
}
