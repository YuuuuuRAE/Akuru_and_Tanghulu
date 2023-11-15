using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    [SerializeField]
    private Text alertText; //알럿 텍스트

    [SerializeField]
    private float AlertTime; //알럿을 띄울 시간
    private float currentTime; //현재 시간

    [SerializeField]
    private GameObject alertUI;
    [SerializeField]
    private int UIHeight; //UI 높이

    private void Update()
    {
        if (GameManager.instance.CurrentLevel > GameManager.instance.AlertLevel)
        {
            alertUI.SetActive(true);
            if(GameManager.instance.CurrentLevel <= 5)
            alertText.text = "레벨 " + GameManager.instance.CurrentLevel.ToString() + " 달성!\n" + "이제 나무에서 " + FruitName(GameManager.instance.CurrentLevel) + " 자라요!";
            else
            {
                alertUI.GetComponent<RectTransform>().sizeDelta = new Vector2(alertUI.GetComponent<RectTransform>().sizeDelta.x, UIHeight);
                alertText.text = "레벨 " + GameManager.instance.CurrentLevel.ToString() + "달성!";
            }
            currentTime += Time.deltaTime;

            if(currentTime >= AlertTime)
            {
                alertUI.SetActive(false);
                GameManager.instance.AlertLevel = GameManager.instance.CurrentLevel;
                currentTime = 0;
            }
        }
    }

    public string FruitName(int F_Num)
    {
        switch (F_Num)
        {
            case 2:
                return "청포도가";
            case 3:
                return "귤이";
            case 4:
                return "파인애플이";
            case 5:
                return "블루베리가";
            default:
                return "";

        }

    }
}
