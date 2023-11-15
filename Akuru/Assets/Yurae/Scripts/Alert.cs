using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    [SerializeField]
    private Text alertText; //�˷� �ؽ�Ʈ
    [SerializeField]
    private int currentLV; // ���� ���� ���� �Ŵ����� ������ ���Ͽ� �˷��� ���� �ؽ�Ʈ�� ��ȯ�ϱ� ����

    [SerializeField]
    private float AlertTime; //�˷��� ��� �ð�
    private float currentTime; //���� �ð�

    [SerializeField]
    private GameObject alertUI;
    [SerializeField]
    private int UIHeight; //UI ����

    private void Update()
    {
        if (GameManager.instance.CurrentLevel > currentLV)
        {
            alertUI.SetActive(true);
            if(GameManager.instance.CurrentLevel <= 5)
            alertText.text = "���� " + GameManager.instance.CurrentLevel.ToString() + " �޼�!\n" + "���� �������� " + FruitName(GameManager.instance.CurrentLevel) + " �ڶ��!";
            else
            {
                alertUI.GetComponent<RectTransform>().sizeDelta = new Vector2(alertUI.GetComponent<RectTransform>().sizeDelta.x, UIHeight);
                alertText.text = "���� " + GameManager.instance.CurrentLevel.ToString() + "�޼�!";
            }
            currentTime += Time.deltaTime;

            if(currentTime >= AlertTime)
            {
                alertUI.SetActive(false);
                currentLV = GameManager.instance.CurrentLevel;
                currentTime = 0;
            }
        }
    }

    public string FruitName(int F_Num)
    {
        switch (F_Num)
        {
            case 2:
                return "û������";
            case 3:
                return "����";
            case 4:
                return "���ξ�����";
            case 5:
                return "��纣����";
            default:
                return "";

        }

    }
}
