using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Player : MonoBehaviour
{
    public UIManager manager;
    public cameraEfect cameraEfect;
    public GameObject cam;
    public GameObject vectorBack;
    public GameObject vectorForward;
    public Rigidbody rgbd;
    private Touch touch;
    [Range(1f, 50f)]
    public float speedPlayer;
    [Range(1f, 30f)]
    public int forwardSpeed;

    private bool speedSphereForward = false;
    private bool touchControl = false;
    

    public void Update()
    {
        //Oyuna týklayýnca touch baþlatma 

        if (Veriables.touchPlay == 1 && speedSphereForward==false)
        {
            //kamera kontrolü
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
           
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }


      //Mobil touch kontrolleri
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                //Arayüz buttonlara basýnca oyunun baþlamamasý
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (touchControl==false)
                    {
                        Veriables.touchPlay = 1;
                        manager.FirstTouch();
                    }
                   
                }
               
            }

            else if (touch.phase == TouchPhase.Moved)
            {
              

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rgbd.velocity = new Vector3(touch.deltaPosition.x * speedPlayer * Time.deltaTime,
                                          transform.position.y,
                                          touch.deltaPosition.y * speedPlayer * Time.deltaTime);

                    if (touchControl == false)
                    {
                        Veriables.touchPlay = 1;
                        manager.FirstTouch();
                    }

                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rgbd.velocity=Vector3.zero;
            }
            
        }
    }
   //fracture daðýlma efekti
      public GameObject[] fractureItems; 

    //player etkileþime girince olacaklar
    public void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.CompareTag("obstacles"))
        {
            cameraEfect.CameraCall();
            manager.StartCoroutine("whiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach(GameObject item in fractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(TimeScaleControl());

        }
       
    }

   

    public IEnumerator TimeScaleControl()
    {
        speedSphereForward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.9f);
        manager.RestartButtonActive();
        rgbd.velocity = Vector3.zero;
    }
}
