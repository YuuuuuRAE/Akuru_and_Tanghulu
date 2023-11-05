using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockFreezer : MonoBehaviour
{
    int lockFreezerNum = 4; //����ִ� ������ ����
    public List<bool> lockFreezer;
    GameObject clickButton;
    public GameObject FreezerUnlockPopUp;

    public Text unlockFreezerText;

    Player player;

    public Text freezerPopUpText;

    private void Start()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();

        FreezerUnlockPopUp.SetActive(false);
    }

    void FreezerPopUpText() //���μҸ� �߰�((�����ϱ�))
    {

        for (int i = 0; i < lockFreezerNum; i++)
        {
            if (lockFreezer[0] == false)
            {
                freezerPopUpText.text = "���� " + 100;
                break;
            }
            else if(lockFreezer[1] == false)
            {
                freezerPopUpText.text = "���� " + 500;
                break;
            }
            else if (lockFreezer[2] == false)
            {
                freezerPopUpText.text = "���� " + 1000;
                break;
            }
            else if (lockFreezer[3] == false)
            {
                freezerPopUpText.text = "���� " + 3000;
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
                Debug.Log("Ŭ���� �����: " + clickButton.name);
                if (i == 0 || lockFreezer[i - 1] == true)
                {
                    FreezerPopUpText();
                    FreezerUnlockPopUp.SetActive(true);
                    unlockFreezerText.text = player.fruits[i + 1].fruitName.ToString()
                                                + " ���ķ縦 ������ ������ ���� �߰��մϴ�.";
                }
                
                else
                {
                    Debug.Log("���� ����� �ر����ּ���");
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
                    clickButton.gameObject.SetActive(false);
                    lockFreezer[i] = true;
                    FreezerUnlockPopUp.SetActive(false);
                }
                else
                {
                    Debug.Log("���� ����� �ر����ּ���");
                }
            }
        }
    }
}
