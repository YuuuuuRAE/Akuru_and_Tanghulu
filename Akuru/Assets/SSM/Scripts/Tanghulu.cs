using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanghulu : MonoBehaviour
{
    // 탕후루 가격 계산 시간은 인스펙터에서 각각 써놓기
    public float price;
    public float payDelay;
    public Fruit fruit;

    // 0 딸기, 1 청포도, 2 귤, 3 파인애플, 4 블루베리
    public int index;

    private void Start()
    {
        price = fruit.price;
    }
}
