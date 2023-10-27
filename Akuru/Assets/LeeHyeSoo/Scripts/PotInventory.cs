using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class PotInventory : MonoBehaviour
{
    public List<Fruit> fruits; //과일을 담을 리스트 

    [SerializeField]
    private Transform slotParent; //슬롯의 부모 potGroup담을 곳
    [SerializeField]
    public Slot[] slots; //potGroup의 하위에 등록된 slot 담을 곳

    Player player;
    public bool isPotFull;
    public int potInventoryNum = 0;
    public bool isPotEmpty;

#if UNITY_EDITOR
    private void OnValidate() //OnValidate는 유니티 에디터에서 바로 작동을 하는 역할
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        isPotFull = false;
        isPotEmpty = true;

        FreshSlot(); //게임이 시작되면 fruit에 들어있는 아이템을 potinventoy에 넣어준다 
    }

    



    
    public void IsPotEmpty() // ((수정하기))
    {
        
        if (isPotEmpty)
        {
            isPotFull = false;
            int FullNum = 0 ;
            for (int i = 0; i <= fruits.Count; i++)
            {
                FullNum = 0;
                if (fruits[i] != null) // 선택된 냄비에 빈자리가 없으면
                {
                    FullNum++;
                }
                
                
            }
            if (FullNum >= fruits.Count)
            {
                isPotEmpty = false;
            }
        }
        else if (!isPotEmpty)
        {
            isPotFull = true;
            int FullNum = fruits.Count;
            for (int i = 0; i <= fruits.Count; i++)
            {
                FullNum = fruits.Count;
                if (fruits[i] != null) // 선택된 냄비에 빈자리가 없으면
                {
                    FullNum--;
                }

                
            }

            if (FullNum <= fruits.Count)
            {
                isPotEmpty = true;
            }
        }
    }

    public void FreshSlot() //아이템이 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능
    {
        int i = 0;
        for (;i < slots.Length; i++) // i의 값이 items와 slots 두 개의 값 보다 작아야만((수정하기))
        {
            slots[i].fruit = fruits[i];
        }
    }

    public void AddFruit(Fruit _fruit)
    {
        RandomSelectPotNum(); //과일이 들어갈 냄비 랜덤위치 선택

        if (fruits[potInventoryNum] == null && !isPotFull) //냄비에 빈공간이 있다면
        {
            fruits[potInventoryNum] = _fruit; //냄비안에 과일 넣음
        }
        else if (fruits[potInventoryNum] != null && !isPotFull)//t선택된 냄비에 빈공간이 없다면
        {
            
            int loopNum = 0;
            while (fruits[potInventoryNum] != null) //비어있는 냄비 자리 찾을때 까지
            {
                Debug.Log("선택된위치에 다른 과일이 있음 / 냄비 재랜덤");
                RandomSelectPotNum(); //다시 랜덤

                if(loopNum++ > 100)
                {
                    break;
                }
                
            }
            fruits[potInventoryNum] = _fruit; //냄비안에 과일 넣음
            Debug.Log("냄비 재랜덤위치:" + potInventoryNum);


        }

        FreshSlot();

    }
    

    public void RandomSelectPotNum()
    {
        //랜덤한 냄비 위치 선택
        potInventoryNum = Random.Range(0, slots.Length);
        Debug.Log("냄비위치 랜덤선택됨. 냄비 위치: " + potInventoryNum);
    }


}
