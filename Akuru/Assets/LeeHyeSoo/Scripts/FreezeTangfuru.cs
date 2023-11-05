using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTangfuru : MonoBehaviour
{
    
    public List<Image> emptyFreezers;
    

    [Header("������ �� ���ķ� ��")]
    public List<int> tangfuruNumInFreezerNow; 
    //���� ������ �ȿ� �ִ� ���ķ� ���� 

    
    private void Start()
    {
        for (int i = 0; i < tangfuruNumInFreezerNow.Count;i++) 
        {
            tangfuruNumInFreezerNow[i] = 0;
        }
    }

    private void Update()
    {
        EmptyFreezer();
    }

    

    public void FullFreezer(int i)
    {
        emptyFreezers[i].color = new Color(1, 1, 1, 0);
    }

    void EmptyFreezer() //�����ҿ� ���ķ簡 ������ ����ִ� �̹����� ��ȯ
    {
        for (int i = 0; i < tangfuruNumInFreezerNow.Count; i++) 
        {
            if (tangfuruNumInFreezerNow[i] == 0)
            {
                emptyFreezers[i].color = new Color(1, 1, 1, 1);
            }
        }
    }
}
