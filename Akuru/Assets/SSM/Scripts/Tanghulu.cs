using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanghulu : MonoBehaviour
{
    // ���ķ� ���� ��� �ð��� �ν����Ϳ��� ���� �����
    public float price;
    public float payDelay;
    public Fruit fruit;

    // 0 ����, 1 û����, 2 ��, 3 ���ξ���, 4 ��纣��
    public int index;

    private void Start()
    {
        price = fruit.price;
    }
}
