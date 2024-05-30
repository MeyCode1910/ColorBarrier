using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraEfect : MonoBehaviour
{
    private bool efectControl = false;

    //engele çarpýnca kamere titreme efekti
  public IEnumerator CameraEfect(float duration,float magnitude)
    {

        Vector3 orginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed<duration)
        {
            float x =  Random.Range(-1f,1f)*magnitude;
            float y =  Random.Range(-1f,1f)*magnitude;

            transform.localPosition = new Vector3(x,y,orginalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = orginalPos;
        
    }
    public void CameraCall() 
    { 
        if (efectControl==false) 
        {
            StartCoroutine(CameraEfect(0.17f, 0.2f));
            efectControl = true;
        }
        
    }
}
