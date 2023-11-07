using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ��ȭ �ؽ�Ʈ ����
    public Text playerLevel;
    public Text ruby;
    public Text coin;

    //���� ����
    public int currentLevel;
    //�������� ���� ��ƾ��� ����ġ
    public int nextLevelUpExp;
    //�������� ���� ���� ���� ����ġ
    public int currentExp;

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
        currentLevel = 1;
        nextLevelUpExp = 3;
        currentExp = 0;

        currentRuby = 99999;
        currentCoin = 3000;
        isdoubleSpeed = false;
    }

    public void Update()
    {
        PlayerLevelUp();

        // ���� ��ȭ
        ruby.text = currentRuby.ToString();
        coin.text = currentCoin.ToString();
        playerLevel.text = currentLevel.ToString();
    }

    void PlayerLevelUp() //�÷��̾� ������
    {
        if(currentExp >= nextLevelUpExp)
        {
            currentLevel += 1;
            currentExp -= nextLevelUpExp; 
            nextLevelUpExp += 5; //exp������ 5
        }

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