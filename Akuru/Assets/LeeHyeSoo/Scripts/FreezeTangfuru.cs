using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTangfuru : MonoBehaviour
{
    
    public List<Image> emptyFreezers;
    //public List<Image> fullFreezers;
    public List<Image> freezeComplete;

    public List<int> tangfuruNumInFreezerNow; //���� ������ �ȿ� �ִ� ���ķ� ���� / �ǸŴ�� �̵��ϸ� (-)�ǵ��� �߰��ϱ�

    //TangfuruGoToFreezer tangfuruGoToFreezer;

    

    private void Start()
    {
        for (int i = 0; i < tangfuruNumInFreezerNow.Count;i++) 
        {
            tangfuruNumInFreezerNow[i] = 0;
        }
    }

    private void Update()
    {
        
    }

    public void FullFreezer(int i)
    {
        emptyFreezers[i].color = new Color(1, 1, 1, 0);
    }

    void EmptyFreezer()
    {
        //emptyFreezers[i].color = new Color(1, 1, 1, 1);
    }
}
