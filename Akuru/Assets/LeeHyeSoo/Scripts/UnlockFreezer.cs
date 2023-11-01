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

    private void Start()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();

        FreezerUnlockPopUp.SetActive(false);
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
