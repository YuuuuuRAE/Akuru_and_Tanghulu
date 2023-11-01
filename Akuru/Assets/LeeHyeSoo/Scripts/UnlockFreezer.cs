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
                Debug.Log("클릭한 냉장고: " + clickButton.name);
                if (i == 0 || lockFreezer[i - 1] == true)
                {
                    FreezerUnlockPopUp.SetActive(true);
                    unlockFreezerText.text = player.fruits[i + 1].fruitName.ToString()
                                                + " 탕후루를 굳히고 보관할 곳을 추가합니다.";
                }
                
                else
                {
                    Debug.Log("이전 냉장고를 해금해주세요");
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
                    Debug.Log("이전 냉장고를 해금해주세요");
                }
            }
        }
    }
}
