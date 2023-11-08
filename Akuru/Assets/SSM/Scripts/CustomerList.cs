using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerList : MonoBehaviour
{
    public GameObject customerList;
    public GameObject counter;

    // �մ� ����Ʈ
    public GameObject[] customers;
    private int currentCustomersNum;
    public Text customerName;
    public Text customerInst;

    // ȣ���� ����
    public float likability;
    public Text currentDrop;
    public Text nextDrop;

    // ���� ��� Ȯ�� �迭 (�׽�Ʈ)
    public float[][] dropValues = {
        new float[] { 50.0f, 60.0f, 70.0f, 80.0f },
        new float[] { 60.0f, 70.0f, 80.0f, 90.0f },
        new float[] { 70.0f, 80.0f, 90.0f, 100.0f },
        new float[] { 85.0f, 90.0f, 95.0f, 100.0f },
        new float[] { 97.0f, 98.0f, 99.0f, 100.0f }
    };

    /*
    // ���� ��� Ȯ�� �迭
    public float[][] dropValues = {
        new float[] { 1.0f, 2.0f, 4.0f, 6.0f },
        new float[] { 1.0f, 2.0f, 4.0f, 7.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 8.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 9.0f },
        new float[] { 1.0f, 3.0f, 5.0f, 10.0f }
    };
    */
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
            currentCustomersNum = customers.Length - 1;
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

        if (currentCustomersNum >= customers.Length)
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
        for (int i = 0; i < customers.Length; i++)
        {
            if (i == currentCustomersNum)
            {
                customers[i].SetActive(true);
            }
            else
            {
                customers[i].SetActive(false);
            }
        }

        switch (currentCustomersNum)
        {
            case 0:
                customerName.text = "������";
                customerInst.text = "���� ���ķ縦 �����ϴ� �����\n��������� �̼Ҹ� ������ �������� ������ ��";
                SetDropValues(0);
                break;
            case 1:
                customerName.text = "û����";
                customerInst.text = "û���� ���ķ縦 �����ϴ� �����.\n����ִ� �������� �ֺ��� ȯ�ϰ� ������.";
                SetDropValues(1);
                break;
            case 2:
                customerName.text = "�ֶ�";
                customerInst.text = "�� ���ķ縦 �����ϴ� �����.\nȣ����� ���� �̰����� �ǵ帮�� ���� ��ģ��.";
                SetDropValues(2);
                break;
            case 3:
                customerName.text = "������";
                customerInst.text = "���ξ��� ���ķ縦 �����ϴ� �����.\n�������� ���ƴٴϴ� ���� �����Ѵ�.";
                SetDropValues(3);
                break;
            case 4:
                customerName.text = "�����";
                customerInst.text = "��纣�� ���ķ縦 �����ϴ� �����.\n��¦ ��¦ �پ�ٴϱ⸦ �����Ѵ�.";
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
