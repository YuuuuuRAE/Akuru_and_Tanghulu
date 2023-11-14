using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerList : MonoBehaviour
{
    public GameObject customerList;
    public GameObject counter;

    // �մ� ����Ʈ
    public GameObject customerImg;
    private int currentCustomersNum;
    public Text customerName;
    public Text customerInst;
    public Sprite[] customersSprite;

    // ȣ���� ����
    public float likability;
    public Text currentDrop;
    public Text nextDrop;


    // ���� ��� Ȯ�� �迭
    public float[][] dropValues = {
        new float[] { 1.0f, 2.0f, 4.0f, 6.0f },
        new float[] { 1.0f, 2.0f, 4.0f, 7.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 8.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 9.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 10.0f }
    };

    public void Start()
    {
        counter = GameObject.Find("Counter");

    }

    // �մ� ����Ʈ UI ����
    // �մ� ����Ʈ UI ����
    public void ListOpen()
    {
        currentCustomersNum = 0;

        if (counter != null)
        {
            likability = counter.GetComponent<Counter>().salesCount[currentCustomersNum];
        }

        customerList.SetActive(true);
        ListChange();
    }

    // �մ� ����Ʈ �� ��ư
    public void ListLeft()
    {
        currentCustomersNum--;

        if (currentCustomersNum < 0)
        {
            currentCustomersNum = 4;
        }

        if (counter != null)
        {
            likability = counter.GetComponent<Counter>().salesCount[currentCustomersNum];
        }

        ListChange();
    }

    // �մ� ����Ʈ �� ��ư
    public void ListRight()
    {
        currentCustomersNum++;

        if (currentCustomersNum >= 5)
        {
            currentCustomersNum = 0;
        }

        if (counter != null)
        {
            likability = counter.GetComponent<Counter>().salesCount[currentCustomersNum];
        }

        ListChange();
    }

    // �մ� ����Ʈ ���� ��ȯ
    public void ListChange()
    {
        switch (currentCustomersNum)
        {
            case 0:
                customerName.text = "������";
                customerInst.text = "���� ���ķ縦 �����ϴ� �����\n��������� �̼Ҹ� ������ �������� ������ ��";
                customerImg.GetComponent<Image>().sprite = customersSprite[0];
                SetDropValues(0);
                break;
            case 1:
                customerName.text = "û����";

                if (GameManager.instance.CurrentLevel >= 2)
                {
                    customerInst.text = "û���� ���ķ縦 �����ϴ� �����.\n����ִ� �������� �ֺ��� ȯ�ϰ� ������.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[1];
                }
                else
                {
                    customerInst.text = "û���� ���ķ縦 �����ϸ� ã�ƿ��� �����.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[2];
                }
                SetDropValues(1);
                break;
            case 2:
                customerName.text = "�ֶ�";
                if (GameManager.instance.CurrentLevel >= 3)
                {
                    customerInst.text = "�� ���ķ縦 �����ϴ� �����.\nȣ����� ���� �̰����� �ǵ帮�� ���� ��ģ��.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[3];
                }
                else
                {
                    customerInst.text = "�� ���ķ縦 �����ϸ� ã�ƿ��� �����.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[4];
                }
                SetDropValues(2);
                break;
            case 3:
                customerName.text = "������";
                if (GameManager.instance.CurrentLevel >= 4)
                {
                    customerInst.text = "���ξ��� ���ķ縦 �����ϴ� �����.\n�������� ���ƴٴϴ� ���� �����Ѵ�.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[5];
                }
                else
                {
                    customerInst.text = "���ξ��� ���ķ縦 �����ϸ� ã�ƿ��� �����.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[6];
                }
                SetDropValues(3);
                break;
            case 4:
                customerName.text = "�����";
                if (GameManager.instance.CurrentLevel >= 5)
                {
                    customerInst.text = "��纣�� ���ķ縦 �����ϴ� �����.\n��¦ ��¦ �پ�ٴϱ⸦ �����Ѵ�.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[7];
                }
                else
                {
                    customerInst.text = "��纣�� ���ķ縦 �����ϸ� ã�ƿ��� �����.";
                    customerImg.GetComponent<Image>().sprite = customersSprite[8];
                }
                SetDropValues(4);
                break;
            default:
                break;
        }
    }

    private void SetDropValues(int index)
    {
        if (likability >= 300)
        {
            currentDrop.text = dropValues[index][3].ToString();
            nextDrop.text = dropValues[index][3].ToString();
        }
        else if (likability >= 200)
        {
            currentDrop.text = dropValues[index][2].ToString();
            nextDrop.text = dropValues[index][3].ToString();
        }
        else if (likability >= 100)
        {
            currentDrop.text = dropValues[index][1].ToString();
            nextDrop.text = dropValues[index][2].ToString();
        }
        else if (likability >= 0)
        {
            currentDrop.text = dropValues[index][0].ToString();
            nextDrop.text = dropValues[index][1].ToString();
        }
    }

    // �մ� ����Ʈ UI �ݱ�
    public void ListClose()
    {
        customerList.SetActive(false);
    }
}
