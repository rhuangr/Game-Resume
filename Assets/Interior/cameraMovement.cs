using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    GameObject MC;

    
    void Start()
    {
        MC = GameObject.Find("MC");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MC.transform.position + new Vector3(0,0,-10);
    }
    
}
