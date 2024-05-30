using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    //Player oyun alanýna çýkamamasýný saðlar
    public Transform vectorRight;
    public Transform vectorForward;
    public Transform vectorLeft;
    public Transform vectorBack;

    public void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.z = Mathf.Clamp(viewPosition.z, vectorBack.transform.position.z, vectorForward.transform.position.z);
        viewPosition.x = Mathf.Clamp(viewPosition.x, vectorLeft.transform.position.x, vectorRight.transform.position.x);
        transform.position = viewPosition;
    }
}
