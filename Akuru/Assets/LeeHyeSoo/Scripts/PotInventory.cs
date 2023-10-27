using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class PotInventory : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ����Ʈ 

    [SerializeField]
    private Transform slotParent; //������ �θ� potGroup���� ��
    [SerializeField]
    public Slot[] slots; //potGroup�� ������ ��ϵ� slot ���� ��

    Player player;
    public bool isPotFull;
    public int potInventoryNum = 0;
    public bool isPotEmpty;

#if UNITY_EDITOR
    private void OnValidate() //OnValidate�� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ����
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        isPotFull = false;
        isPotEmpty = true;

        FreshSlot(); //������ ���۵Ǹ� fruit�� ����ִ� �������� potinventoy�� �־��ش� 
    }

    



    
    public void IsPotEmpty() // ((�����ϱ�))
    {
        
        if (isPotEmpty)
        {
            isPotFull = false;
            int FullNum = 0 ;
            for (int i = 0; i <= fruits.Count; i++)
            {
                FullNum = 0;
                if (fruits[i] != null) // ���õ� ���� ���ڸ��� ������
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
                if (fruits[i] != null) // ���õ� ���� ���ڸ��� ������
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

    public void FreshSlot() //�������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ���
    {
        int i = 0;
        for (;i < slots.Length; i++) // i�� ���� items�� slots �� ���� �� ���� �۾ƾ߸�((�����ϱ�))
        {
            slots[i].fruit = fruits[i];
        }
    }

    public void AddFruit(Fruit _fruit)
    {
        RandomSelectPotNum(); //������ �� ���� ������ġ ����

        if (fruits[potInventoryNum] == null && !isPotFull) //���� ������� �ִٸ�
        {
            fruits[potInventoryNum] = _fruit; //����ȿ� ���� ����
        }
        else if (fruits[potInventoryNum] != null && !isPotFull)//t���õ� ���� ������� ���ٸ�
        {
            
            int loopNum = 0;
            while (fruits[potInventoryNum] != null) //����ִ� ���� �ڸ� ã���� ����
            {
                Debug.Log("���õ���ġ�� �ٸ� ������ ���� / ���� �緣��");
                RandomSelectPotNum(); //�ٽ� ����

                if(loopNum++ > 100)
                {
                    break;
                }
                
            }
            fruits[potInventoryNum] = _fruit; //����ȿ� ���� ����
            Debug.Log("���� �緣����ġ:" + potInventoryNum);


        }

        FreshSlot();

    }
    

    public void RandomSelectPotNum()
    {
        //������ ���� ��ġ ����
        potInventoryNum = Random.Range(0, slots.Length);
        Debug.Log("������ġ �������õ�. ���� ��ġ: " + potInventoryNum);
    }


}
