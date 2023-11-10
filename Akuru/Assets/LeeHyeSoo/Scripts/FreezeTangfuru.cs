using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTangfuru : MonoBehaviour
{
    GameManager gameManager;

    public List<Image> emptyFreezers;
    

    [Header("굳히소 안 탕후루 수")]
    public List<int> tangfuruNumInFreezerNow; 
    //현재 굳히소 안에 있는 탕후루 개수 

    
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        for (int i = 0; i < tangfuruNumInFreezerNow.Count;i++) 
        {
            tangfuruNumInFreezerNow[i] = 0;
        }
    }

    private void Update()
    {
        EmptyFreezer();

        for (int i = 0;i < emptyFreezers.Count;i++)
        {
            gameManager.tangfuruNumList[i] = tangfuruNumInFreezerNow[i];
        }
        
    }

    

    public void FullFreezer(int i)
    {
        emptyFreezers[i].color = new Color(1, 1, 1, 0);
    }

    void EmptyFreezer() //굳히소에 탕후루가 없으면 비어있는 이미지로 전환
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
