using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpeed : MonoBehaviour
{
    // 배속 버튼
    public void ClickDoubleSpeed()
    {
        // 기본속도일 때
        if (!GameManager.instance.isdoubleSpeed)
        {
            Time.timeScale = 2.0f;
            GameManager.instance.isdoubleSpeed = true;
            Debug.Log("게임 2배속");
        }
        // 두배속일 때
        else if (GameManager.instance.isdoubleSpeed)
        {
            Time.timeScale = 1.0f;
            GameManager.instance.isdoubleSpeed = false;
            Debug.Log("게임 정상 배속");
        }
    }
}
