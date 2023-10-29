using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEditor.EditorTools;

public class GameManager : MonoBehaviour
{
    // UI ����
    public GameObject customerList;
    public GameObject purchaseStand;

    // ������ �߰� â
    public GameObject[] purchase;
    public int purchaseNum;

    // �մ� ����Ʈ
    public GameObject[] customers;
    private int currentCustomersNum;
    public Button listLeft;
    public Button listRight;
    public Text customerName;
    public Text customerInst;
    public Text likeability;

    // ��ȭ ����
    public Text ruby;
    public Text coin;

    // ���� ��ȭ ������
    public int currentRuby;
    public int currentCoin;

    // ��� �ð� �����̴�
    public Slider progress;

    // ���� ���ӹ�ư ����
    public bool doubleSpeed = false;

    // �մ�, ���ķ� ���ڰ� ��������
    public CustomerSpawner customerSpawner;
    public TanghuluSpawner tanghuluSpawner;
    public int favorite;

    //Sinleton Pattern
    public static GameManager instance;
    private void Awake()
    {
        customerSpawner = FindObjectOfType<CustomerSpawner>();
        tanghuluSpawner = FindObjectOfType<TanghuluSpawner>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("�ı�");
        }
    }

    public void Start()
    {
        currentRuby = 99999;
        currentCoin = 700;
    }


    public void Update()
    {
        // ���� ��ȭ
        ruby.text = "��� : " + currentRuby;
        coin.text = "���� : " + currentCoin;

        // ��� �ð�
        {

        }
    }

    public void PayCheck()
    {
        GameObject[] tanghulus = instance.tanghuluSpawner.tanghulus;

        GameObject tanghuluWithFavorite = null;

        for (int i = 0; i < tanghulus.Length; i++)
        {
            if (tanghulus[i] != null)
            {
                GameObject tanghuluComponent = tanghulus[i].GetComponent<GameObject>();

                if (tanghuluComponent != null && i == favorite)
                {
                    tanghuluWithFavorite = tanghuluComponent;
                    tanghuluWithFavorite.SetActive(false);

                    Debug.Log(favorite);
                    break; // ���ϴ� ������Ʈ�� ã�����Ƿ� ���� ����
                }
            }
        }


    }

    // ������ ����
    // ������ ���� UI ����
    public void PurchaseOpen(int buttonIndex)
    {
        if (buttonIndex == 0 || !purchase[(buttonIndex - 1)].activeSelf)
        {
            purchaseNum = buttonIndex;
            purchaseStand.SetActive(true);
            Debug.Log((purchaseNum + 2) + "�� ������ ����");
        }
        else
        {
            Debug.Log("���� �������� ���� �ر����ּ���");
        }
    }

    // ������ ����
    public void Purchase()
    {
        if (currentCoin >= 200)
        {
            currentCoin -= 200;
            Debug.Log("���� ���� : " + currentCoin);
            purchaseStand.SetActive(false);
            purchase[purchaseNum].SetActive(false);
            Debug.Log((purchaseNum + 2) + "�� ������ �ر�");
        }
        else
        {
            Debug.Log("������ �����մϴ�.");
        }
    }

    // ������ �ݱ�
    public void PurchaseClose()
    {
        purchaseStand.SetActive(false);
    }


    // ��� ���ӹ�ư
    public void Acceleration()
    {
        Debug.Log("��� ����");
    }


    // ���� ��ư
    public void Shop()
    {
        Debug.Log("����");
    }


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


    //�ֹ� ������ �̵�
    public void Kitchen()
    {
        Debug.Log("�ֹ�� �̵�");
    }


    // ��� ��ư
    public void DoubleSpeed()
    {
        // ����� �����ӵ�, ����� �̵��ӵ�, ���ӵ� ����
        // �⺻�ӵ��� ��
        if (!doubleSpeed)
        {
            Debug.Log("���� 2���");
            doubleSpeed = true;
        }
        // �ι���� ��
        else if (doubleSpeed)
        {
            Debug.Log("���� ���� ���");
            doubleSpeed = false;
        }
    }


    // ����â UI ����
    public void Setting()
    {
        Debug.Log("����â ����");
    }


    // ����â UI ����
    public void Level()
    {
        Debug.Log("����â ����");
    }


    // �⼮ üũ UI ����
    public void Check()
    {
        Debug.Log("�⼮üũ ����");
    }


    // ����Ʈâ UI ����
    public void Quest()
    {
        Debug.Log("����Ʈ ����");
    }


    // �귿 UI ����
    public void Roulette()
    {
        Debug.Log("�귿 ����");
    }


    // �̺�Ʈ UI ����
    public void Event()
    {
        Debug.Log("�̺�Ʈ ����");
    }
}