using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectControl = 0;

    public Image fillRateImage;
    public GameObject player;
    public GameObject finishLine;

    public Animator layoutAnimator;

    public TextMeshProUGUI coinText;
    //buttons

    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject layoutBackround;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;

    public GameObject touchControl;
    public GameObject toptomove_Text;
    public GameObject noAds;
    public GameObject shop;

    public GameObject Restart;

    //Oyun sonu ekraný
    public GameObject finishScreen;
    public GameObject redBackground;
    public GameObject complated;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject continuee;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public TextMeshProUGUI achievedText;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound")==false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration")== false)
        {
            PlayerPrefs.SetInt("Vibration", 1);

        }
        coinTextUpdate();

    }

    public void Update()
    {
        if (radial_shine==true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 30 * Time.deltaTime));
        }
        fillRateImage.fillAmount = (player.transform.position.z)/(finishLine.transform.position.z);

    }

    public void FirstTouch()
    {
        touchControl.SetActive(false);
        toptomove_Text.SetActive(false);
        noAds.SetActive(false);
        shop.SetActive(false);
        settingsOpen.SetActive(false);
        settingsClose.SetActive(false);
        layoutBackround.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }
  
    public void coinTextUpdate()
    {
        coinText.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        Restart.SetActive(true);
    }

    public void RestartScene()
    {
        Veriables.touchPlay = 0;

        Time.timeScale = 1f;

        //Aktif sahneyi alýp resetler
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        Veriables.touchPlay = 0;

        Time.timeScale = 1f;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //public void ContinueScene()
    //{
    //    Veriables.touchPlay = 0;

    //    Time.timeScale = 1f;

        
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.3f;

       
        finishScreen.SetActive(true);
        redBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        complated.SetActive(true);
        yield return new WaitForSecondsRealtime(0.7f);
        radial_shine.SetActive(true);
        coin.SetActive(true);
        
        
        yield return new WaitForSecondsRealtime(0.7f);
        continuee.SetActive(true);

    }
       
    public IEnumerator AfterrewardButton()
    {
        achievedCoin.SetActive(true);
        yield return new WaitForSecondsRealtime(0.7f);      
        rewarded.SetActive(false);
        continuee.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);

        for (int i = 0; i < 400; i+=4)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }
    }
    


// buttons fonks

         public void Settings_Open()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        layoutAnimator.SetTrigger("slide_in");

        if (PlayerPrefs.GetInt("Sound")==1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }else if(PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration")==1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }


    } 
    public void Settings_Close()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        layoutAnimator.SetTrigger("slide_out");

    }
    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
       
       AudioListener.volume = 0;    //ses aç kapama
        PlayerPrefs.SetInt("Sound",2);
    }
    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration",2 );
    }

    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);

        PlayerPrefs.SetInt("Vibration", 1);
    }

    //haskey
    //get veriyi getirir
    //set veriyi yerleþtirir


    //engele çarpýnca beyaz efekt gelmesi
    public IEnumerator whiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r,whiteEffectImage.color.g,whiteEffectImage.color.b,1))
            {
                effectControl = 1;
               
            }   

        }
         while (effectControl == 1)
         {
            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b,0))
            {
                effectControl = 2;
            }
         }

         if (effectControl == 2)
        {
           
        }

    }
}

