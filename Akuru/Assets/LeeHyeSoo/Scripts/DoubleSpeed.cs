using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpeed : MonoBehaviour
{
    // ��� ��ư
    public void ClickDoubleSpeed()
    {
        // �⺻�ӵ��� ��
        if (!GameManager.instance.isdoubleSpeed)
        {
            Time.timeScale = 2.0f;
            GameManager.instance.isdoubleSpeed = true;
            Debug.Log("���� 2���");
        }
        // �ι���� ��
        else if (GameManager.instance.isdoubleSpeed)
        {
            Time.timeScale = 1.0f;
            GameManager.instance.isdoubleSpeed = false;
            Debug.Log("���� ���� ���");
        }
    }
}
