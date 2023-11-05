using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class PotInventory : MonoBehaviour
{
    public List<Fruit> fruits; //과일을 담을 리스트 

    [SerializeField]
    private Transform slotParent; //슬롯의 부모 potGroup담을 곳

    [Header("과일 슬롯")]
    [SerializeField]
    public Slot[] slots; //potGroup의 하위에 등록된 slot 담을 곳
    [Header("탕후루 슬롯")]
    public TangfuruSlot[] tangfuruSlots; //potGroup의 하위에 등록된 TangfuruSlot 담을 곳

    RectTransform fruit_Tf;
    RectTransform tangfuru_Tf; //이미지 ((수정하기))

    //Player player;
    public bool isPotFull; //과일이 냄비에 가득 찼는지
    public int potInventoryNum = 0; //냄비 위치 인덱스

    [Header("냄비 얼마나 찼나")]
    public int FullNum; // 냄비가 몇개나 차있는지

    [Header("과일 끓이는 중")]
    public List<bool> isBoil;
    public List<float> startBoil;

    [Header("탕후루 클릭")]
    public GameObject TangfuruClick;

    TangfuruGoToFreezer tangfuruGoToFreezer;

#if UNITY_EDITOR
    private void OnValidate() //OnValidate는 유니티 에디터에서 바로 작동을 하는 역할
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        tangfuruSlots = slotParent.GetComponentsInChildren<TangfuruSlot>();
    }
#endif

    void Awake()
    {
        tangfuruGoToFreezer = FindAnyObjectByType<TangfuruGoToFreezer>();
        isPotFull = false;
        FullNum = 0;

        FreshSlot(); //게임이 시작되면 fruit에 들어있는 아이템을 potinventoy에 넣어준다 
    }

    private void Update()
    {
        BoilFruit();
        IsPotEmpty();
    }

    void BoilFruit() //과일 냄비조리 확인
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isBoil[i] == true) // 해당인덱스의 isBoil이 true면
            {
                startBoil[i] += Time.deltaTime; //타이머 시작
                if (startBoil[i] >= fruits[i].fruitInPotTime) //타이머 값이 조리시간에 도달했다면
                {
                    Debug.Log(fruits[i] + "조리완료");
                    
                    tangfuruSlots[i].gameObject.SetActive(true);
                    
                    isBoil[i] = false;
                    
                }
            }
            else if (isBoil[i] == false)// 해당인덱스의 isBoil이 false면
            {
                startBoil[i] = 0;
            }
        }
    }

    

    
    
    public void IsPotEmpty() // 냄비가 비어있는지 검사 ((수정하기))
    {
        if (FullNum >= slots.Length)
        {
            isPotFull = true;
            Debug.LogWarning("냄비가득참");

        }
        else if (FullNum < slots.Length)
        {
            isPotFull = false;

        }
    }

    public void FreshSlot() //아이템이 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능
    {
        
        for (int i = 0; i < slots.Length; i++) // i의 값이 items와 slots 두 개의 값 보다 작아야만((수정하기))
        {
            slots[i].fruit = fruits[i];
            tangfuruSlots[i].fruit = fruits[i];
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
        FullNum += 1;

        

        //냄비조리
        isBoil[potInventoryNum] = true; // 선택된 인덱스의 끓기 true
        tangfuruSlots[potInventoryNum].gameObject.SetActive(false);

        

        FreshSlot();

        //이미지 flip
        fruit_Tf = slots[potInventoryNum].GetComponent<RectTransform>();
        tangfuru_Tf = tangfuruSlots[potInventoryNum].GetComponent<RectTransform>();
        PotTangfuruImgFlip(); //냄비가 가득차는 오류있음 ((수정하기))

    }


    void PotTangfuruImgFlip() //냄비에 담긴 탕후루가 상하좌우가 랜덤으로 flip
    {
        

        int flip = Random.Range(0, 4);

        if (flip == 0)
        {
            Debug.LogWarning("0_Flip");
            fruit_Tf.localScale = new Vector3(1, 1, 1);
            tangfuru_Tf.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else if(flip == 1)
        {
            Debug.LogWarning("1_Flip");
            fruit_Tf.localScale = new Vector3(-1, 1, 1);
            tangfuru_Tf.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
        else if (flip == 2)
        {
            Debug.LogWarning("2_Flip");
            fruit_Tf.localScale = new Vector3(1, -1, 1);
            tangfuru_Tf.localScale = new Vector3(1.5f, -1.5f, 1);
        }
        else if (flip == 3)
        {
            Debug.LogWarning("3_Flip");
            fruit_Tf.localScale = new Vector3(-1, -1, 1);
            tangfuru_Tf.localScale = new Vector3(-1.5f, -1.5f, 1);
        }
    }

    



    public void RandomSelectPotNum()
    {
        //랜덤한 냄비 위치 선택
        potInventoryNum = Random.Range(0, slots.Length);
        Debug.Log("냄비위치 랜덤선택됨. 냄비 위치: " + potInventoryNum);
    }


}
