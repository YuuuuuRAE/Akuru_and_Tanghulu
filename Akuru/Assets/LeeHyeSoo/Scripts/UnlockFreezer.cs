using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockFreezer : MonoBehaviour
{
    int lockFreezerNum = 4; //잠겨있는 굳히소 개수
    //public List<bool> lockFreezer;
    GameObject clickButton;
    public GameObject FreezerUnlockPopUp;

    public Text unlockFreezerText;

    Player player;
    //GameManager gameManager;

    int payCoin;

    public Text freezerPopUpText;

    PlayAudio playAudio;

    private void Start()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        //gameManager = FindAnyObjectByType<GameManager>();
        playAudio = FindAnyObjectByType<PlayAudio>();

        FreezerUnlockPopUp.SetActive(false);
        SetUnlockFreezer();
    }

    void FreezerPopUpText() 
    {

        for (int i = 0; i < lockFreezerNum; i++)
        {
            if (GameManager.instance.lockFreezer[0] == false)
            {
                payCoin = 100;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            else if(GameManager.instance.lockFreezer[1] == false)
            {
                payCoin = 500;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            else if (GameManager.instance.lockFreezer[2] == false)
            {
                payCoin = 1000;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            else if (GameManager.instance.lockFreezer[3] == false)
            {
                payCoin = 3000;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            
        }
        
        

        
    }

    public void ClickUnlockfreezer()
    {
        clickButton = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < lockFreezerNum; i++)
        {
            if (clickButton.name == "UnlockButton (" + i + ")")
            {
                if (i == 0 || GameManager.instance.lockFreezer[i - 1] == true)
                {
                    FreezerPopUpText();
                    FreezerUnlockPopUp.SetActive(true);
                    
                }
                
            }
        }

    }
    
    public void PurchaseFreezer()
    {
        for (int i = 0; i < lockFreezerNum; i++)
        {
            if (clickButton.name == "UnlockButton (" + i + ")")
            {
                if (i == 0 || GameManager.instance.lockFreezer[i - 1] == true)
                {
                    if(GameManager.instance.currentCoin >= payCoin)
                    {
                        clickButton.gameObject.SetActive(false);
                        GameManager.instance.lockFreezer[i] = true;

                        GameManager.instance.currentCoin -= payCoin;
                        playAudio.PlayConfirm();

                        FreezerUnlockPopUp.SetActive(false);
                    }
                    
                }
                
            }
        }
    }

    void SetUnlockFreezer()
    {
        for(int i = 0;i < lockFreezerNum;i++)
        {
            if(GameManager.instance.lockFreezer[i] == true)
            {
                if(GameObject.Find(name: "UnlockButton (" + i + ")").activeSelf == true)
                {
                    GameObject.Find(name: "UnlockButton (" + i + ")").SetActive(false);
                }
                
            }
        }
    }
}
