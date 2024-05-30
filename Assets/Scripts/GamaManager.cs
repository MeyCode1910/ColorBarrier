using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public UIManager uiManager;
 
    public void Start()
    {
        CoinCalculator(0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& gameObject.CompareTag("Finish"))
        {
            Debug.Log("oyun bitti");
            
            CoinCalculator(100);
            uiManager.coinTextUpdate();
            uiManager.FinishScreen();
        }
    }

     public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldscore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldscore + money);
        } else
            PlayerPrefs.SetInt("moneyy", 0);
    }
}
