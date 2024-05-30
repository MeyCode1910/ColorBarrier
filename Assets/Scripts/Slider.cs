using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;
    public float speed;
    public void FixedUpdate()
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(position1,position2,Mathf.PingPong(Time.time*speed,1.0f));
    }
}