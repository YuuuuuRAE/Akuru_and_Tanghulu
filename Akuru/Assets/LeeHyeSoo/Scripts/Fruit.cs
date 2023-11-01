using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Fruit : ScriptableObject
{

    public string fruitName; //���� �̸�
    public Sprite fruitImage; //���� �̹���
    public Sprite tangfuruImage; //���ķ� �̹���
    public float making_time; //�����ð�
    public int fruitAmount; //���� ����
    public float fruitInPotTime; // ���� �����ð�

    [Header("������ â: ���� ������")]
    public int rcpLevel; //���ķ� ����
    public int price; //= �ش� ������ ���� �޼� �� �Ǹżҿ����� ���ķ� �Ǹ� ����
    public int exp; //= �ش� ������ ������ �� ���ķ� ���۽� ����ġ
    public int rqQuantity; //���� ������ �������� �ϱ� ���� �ʿ� ���� ����
    public int rqCoin; // �������� �ʿ��� ����
    public int rqRuby; // �������� �ʿ��� ���


    public int rqQuantityNow; //���� �������� ���� ���� ���� ����
    public int saleTangfuruNum; // ���� ���ķ� �Ǹ� ����

    
}
