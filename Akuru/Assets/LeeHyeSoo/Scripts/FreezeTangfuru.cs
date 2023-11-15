using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTangfuru : MonoBehaviour
{

    public List<Image> emptyFreezers;
    
    
    private void Start()
    {

        
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
        for (int i = 0; i < GameManager.instance.tangfuruNumList.Length; i++) 
        {
            if (GameManager.instance.tangfuruNumList[i] == 0)
            {
                emptyFreezers[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                emptyFreezers[i].color = new Color(1, 1, 1, 0);
            }
            
        }
    }

    
}
