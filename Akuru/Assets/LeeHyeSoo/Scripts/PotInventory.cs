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
    public bool isPotFull = false;

#if UNITY_EDITOR
    private void OnValidate() //OnValidate는 유니티 에디터에서 바로 작동을 하는 역할
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        //selectNum = player.RandomSelectTangfuru();

        FreshSlot(); //게임이 시작되면 fruit에 들어있는 아이템을 potinventoy에 넣어준다 
    }

    public void FreshSlot() //아이템이 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능
    {
        int i = 0;
        for (; i < fruits.Count && i < slots.Length; i++) // i의 값이 items와 slots 두 개의 값 보다 작아야만
        {
            slots[i].fruit = fruits[i];
        }
        for (; i < slots.Length; i++) 
        {
            slots[i].fruit = null;

            //slot에 아이템을 다 저장하고 난 후에도 slot이 남아 있다면
            //다음 for문이 실행되어 빈 슬롯들은 모두 null 처리
        }
    }

    public void AddFruit(Fruit _fruit)
    {
        if (fruits.Count < slots.Length)
        {
            isPotFull = false;
            fruits.Add(_fruit);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 차 있습니다.");
            isPotFull = true;
        }
    }

    
}
