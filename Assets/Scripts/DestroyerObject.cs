using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObject : MonoBehaviour
{
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Untagged")|| hit.gameObject.CompareTag("obstacles"))
        {
            Destroy(hit.gameObject);
        }
    }
}
