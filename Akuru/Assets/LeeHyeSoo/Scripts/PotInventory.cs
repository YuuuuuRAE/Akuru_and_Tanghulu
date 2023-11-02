using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class PotInventory : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ����Ʈ 

    [SerializeField]
    private Transform slotParent; //������ �θ� potGroup���� ��

    [Header("���� ����")]
    [SerializeField]
    public Slot[] slots; //potGroup�� ������ ��ϵ� slot ���� ��
    [Header("���ķ� ����")]
    public TangfuruSlot[] tangfuruSlots; //potGroup�� ������ ��ϵ� TangfuruSlot ���� ��

    //Player player;
    public bool isPotFull; //������ ���� ���� á����
    public int potInventoryNum = 0; //���� ��ġ �ε���

    [Header("���� �󸶳� á��")]
    public int FullNum; // ���� ��� ���ִ���

    [Header("���� ���̴� ��")]
    public List<bool> isBoil;
    public List<float> startBoil;

    [Header("���ķ� Ŭ��")]
    public GameObject TangfuruClick;

    TangfuruGoToFreezer tangfuruGoToFreezer;

#if UNITY_EDITOR
    private void OnValidate() //OnValidate�� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ����
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

        FreshSlot(); //������ ���۵Ǹ� fruit�� ����ִ� �������� potinventoy�� �־��ش� 
    }

    private void Update()
    {
        BoilFruit();
        IsPotEmpty();
    }

    void BoilFruit() //���� �������� Ȯ��
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isBoil[i] == true) // �ش��ε����� isBoil�� true��
            {
                startBoil[i] += Time.deltaTime; //Ÿ�̸� ����
                if (startBoil[i] >= fruits[i].fruitInPotTime) //Ÿ�̸� ���� �����ð��� �����ߴٸ�
                {
                    Debug.Log(fruits[i] + "�����Ϸ�");
                    
                    tangfuruSlots[i].gameObject.SetActive(true);
                    
                    isBoil[i] = false;
                    
                }
            }
            else if (isBoil[i] == false)// �ش��ε����� isBoil�� false��
            {
                startBoil[i] = 0;
                if(Input.GetMouseButtonDown(0))
                {
                    IsClickTangfuru(i);
                }
            }
        }


    }

    void IsClickTangfuru(int i) //(((((((((((((((�����ϱ�)))))))))))))))))))
    {
        //Color slotsColorNow = slots[i].image.color;
        //Color tangfuruSlotsColorNow = tangfuruSlots[i].image.color;

        if (TangfuruClick.gameObject.activeSelf == true)
        {
            Debug.LogWarning("IsClickTangfuru����");
            slots[i].image.color = new Color(1, 1, 1, 0);
            tangfuruSlots[i].image.color = new Color(1, 1, 1, 0);

            //if (tangfuruGoToFreezer.hitObj1.tag == "Tangfuru")
            //{
            //    Debug.LogWarning("IsClickTangfuru����");
            //    slots[i].image.color = new Color(1, 1, 1, 0);
            //    tangfuruSlots[i].image.color = new Color(1, 1, 1, 0);
            //}
        }
        else if (TangfuruClick.gameObject.activeSelf == false)
        {
            //slots[i].image.color = slotsColorNow;
            //tangfuruSlots[i].image.color = tangfuruSlotsColorNow;

            //slots[i].image.color = new Color(1, 1, 1, 1);
            //tangfuruSlots[i].image.color = new Color(1, 1, 1, 1);
        }
    }

    
    
    public void IsPotEmpty() // ���� ����ִ��� �˻� ((�����ϱ�))
    {
        if (FullNum >= slots.Length)
        {
            isPotFull = true;
            Debug.LogWarning("���񰡵���");

        }
        else if (FullNum < slots.Length)
        {
            isPotFull = false;

        }


    }

    

    public void FreshSlot() //�������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ���
    {
        
        for (int i = 0; i < slots.Length; i++) // i�� ���� items�� slots �� ���� �� ���� �۾ƾ߸�((�����ϱ�))
        {
            slots[i].fruit = fruits[i];
            tangfuruSlots[i].fruit = fruits[i];
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
        FullNum += 1;

        //��������
        isBoil[potInventoryNum] = true; // ���õ� �ε����� ���� true
        tangfuruSlots[potInventoryNum].gameObject.SetActive(false);

        FreshSlot();

    }
    

    public void RandomSelectPotNum()
    {
        //������ ���� ��ġ ����
        potInventoryNum = Random.Range(0, slots.Length);
        Debug.Log("������ġ �������õ�. ���� ��ġ: " + potInventoryNum);
    }


}
