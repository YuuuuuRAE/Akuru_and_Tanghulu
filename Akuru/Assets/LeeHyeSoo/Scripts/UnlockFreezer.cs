using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockFreezer : MonoBehaviour
{
    int lockFreezerNum = 4; //잠겨있는 굳히소 개수
    public List<bool> lockFreezer;
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
    }

    void FreezerPopUpText() //코인소모 추가((수정하기))
    {

        for (int i = 0; i < lockFreezerNum; i++)
        {
            if (lockFreezer[0] == false)
            {
                payCoin = 100;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            else if(lockFreezer[1] == false)
            {
                payCoin = 500;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            else if (lockFreezer[2] == false)
            {
                payCoin = 1000;
                freezerPopUpText.text = payCoin.ToString() + "   ";
                break;
            }
            else if (lockFreezer[3] == false)
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
                if (i == 0 || lockFreezer[i - 1] == true)
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
                if (i == 0 || lockFreezer[i - 1] == true)
                {
                    if(GameManager.instance.currentCoin >= payCoin)
                    {
                        clickButton.gameObject.SetActive(false);
                        lockFreezer[i] = true;

                        GameManager.instance.currentCoin -= payCoin;
                        playAudio.PlayConfirm();

                        FreezerUnlockPopUp.SetActive(false);
                    }
                    
                }
                
            }
        }
    }
}
