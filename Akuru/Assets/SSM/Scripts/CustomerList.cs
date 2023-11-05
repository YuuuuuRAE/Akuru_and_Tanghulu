using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerList : MonoBehaviour
{
    public GameObject customerList;

    // �մ� ����Ʈ
    public GameObject[] customers;
    private int currentCustomersNum;
    public Text customerName;
    public Text customerInst;
    public Text likeability;

    // �մ� ����Ʈ UI ����
    // �մ� ����Ʈ UI ����
    public void ListOpen()
    {
        currentCustomersNum = 0;
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
                break;
            case 1:
                customerName.text = "û����";
                customerInst.text = "û���� ���ķ縦 �����ϴ� �����.\n����ִ� �������� �ֺ��� ȯ�ϰ� ������.";
                break;
            case 2:
                customerName.text = "�ֶ�";
                customerInst.text = "�� ���ķ縦 �����ϴ� �����.\nȣ����� ���� �̰����� �ǵ帮�� ���� ��ģ��.";
                break;
            case 3:
                customerName.text = "������";
                customerInst.text = "���ξ��� ���ķ縦 �����ϴ� �����.\n�������� ���ƴٴϴ� ���� �����Ѵ�.";
                break;
            case 4:
                customerName.text = "�����";
                customerInst.text = "��纣�� ���ķ縦 �����ϴ� �����.\n��¦ ��¦ �پ�ٴϱ⸦ �����Ѵ�.";
                break;
            default:
                break;
        }

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
    }

    // �մ� ����Ʈ UI �ݱ�
    public void ListClose()
    {
        customerList.SetActive(false);
    }
}
