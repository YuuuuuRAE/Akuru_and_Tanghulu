using System;
using System.Collections.Generic;

[Serializable] // ����ȭ

public class Data
{
    public bool iSFirstStart;
    public int AlertLevel;
    public int openStandNum; // �رݵ� ������ ����
    public bool isFullStand; // �����밡 ���� ���ִ��� üũ
    public int MaxFruitType; //�ִ� ���� Ÿ��
    public bool isUnlock;
    public int CurrentLevel;
    public float MaxXp; // �ִ� ����ġ
    public float CurrentXp; //���� ����ġ
    public float IncrementXp; //����ġ ������
    public float currentRuby;
    public float currentCoin;
    public string SceneName;
    public string BGMname;
    public bool isBGM; //��� ����
    public bool isSound; //ȿ���� ����
    public bool isVibe; //���� ����

    public List<bool> fruit_FirstMaking;
    public bool isSelectFT; // ���� ���� ��ư�� Ŭ���Ǿ� �ֳ�?
    public int[] fruitNumList = new int[5];
    public int[] tangfuruNumList; // ���ķ� ���� / ���ۼҿ��� ���� ���ķ� �̰��� ���̵���
    public int[] standsNumList; // �����ؾ��ϴ� ���ķ� ������ ����
    public List<int> tangfuruNowNum_Rcp; // �������� 0���� ���ư�
    public List<int> tangfuruAllNum_Rcp;
    public List<bool> lockFreezer;
}