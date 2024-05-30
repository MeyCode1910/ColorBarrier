using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public int forwardSpeed;
   
    void Update()
    {
        if (Veriables.touchPlay==1)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }
       
        
    }
}
