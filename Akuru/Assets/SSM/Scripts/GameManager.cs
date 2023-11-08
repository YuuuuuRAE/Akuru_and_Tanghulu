using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ��ȭ �ؽ�Ʈ ����
    public Text ruby;
    public Text coin;

    // ���� ��ȭ ������
    public float currentRuby;
    public float currentCoin;

    // ���� ���ӹ�ư ����
    public bool isdoubleSpeed;

    // Sinleton Pattern
    public static GameManager instance;
    private void Awake()
    {
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
        currentRuby = 1000;
        currentCoin = 3000;
        isdoubleSpeed = false;
    }

    void Update()
    {
        // ���� ��ȭ
        ruby.text = FormatNumber(currentRuby);
        coin.text = FormatNumber(currentCoin);
    }

    // ���ڸ� õ ���� ���� ��ȣ�� �ִ� ���ڿ��� ����ȭ
    private string FormatNumber(float number)
    {
        return string.Format("{0:N0}", number);
    }


    // �� ��ư�� �����ø� �˴ϴ�.
    // �����(AT_100) ������ �̵�
    public void AT_100()
    {
        SceneManager.LoadScene("Production_Plant");
        Debug.Log("����� ������ �̵�");
    }

    // ���ۼ�(AT_200) ������ �̵�
    public void AT_200()
    {
        SceneManager.LoadScene("AT_200");
        Debug.Log("���ۼ� ������ �̵�");
    }

    // �Ǹż�(AT_300) ������ �̵�
    public void AT_300()
    {
        SceneManager.LoadScene("Sales");
        Debug.Log("�Ǹż� ������ �̵�");
    }

    // �귿 ������ �̵�
    public void Roulette()
    {
        SceneManager.LoadScene("Roulette");
        Debug.Log("�귿 ������ �̵�");
    }

    // ��� ��ư
    public void DoubleSpeed()
    {
        // �⺻�ӵ��� ��
        if (!isdoubleSpeed)
        {
            Time.timeScale = 2.0f;
            isdoubleSpeed = true;
            Debug.Log("���� 2���");
        }
        // �ι���� ��
        else if (isdoubleSpeed)
        {
            Time.timeScale = 1.0f;
            isdoubleSpeed = false;
            Debug.Log("���� ���� ���");
        }
    }

    // ���� ��ư
    public void Shop()
    {
        Debug.Log("����");
    }


    // ����â UI ���� ��ư
    public void Setting()
    {
        Debug.Log("����â ����");
    }


    // ����â UI ���� ��ư
    public void Level()
    {
        Debug.Log("����â ����");
    }


    // �⼮ üũ UI ���� ��ư
    public void Check()
    {
        Debug.Log("�⼮üũ ����");
    }


    // ����Ʈâ UI ���� ��ư
    public void Quest()
    {
        Debug.Log("����Ʈ ����");
    }


    // �̺�Ʈ UI ���� ��ư
    public void Event()
    {
        Debug.Log("�̺�Ʈ ����");
    }
}