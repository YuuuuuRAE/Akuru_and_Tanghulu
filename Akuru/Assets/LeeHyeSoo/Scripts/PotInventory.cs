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

    RectTransform fruit_Tf;
    RectTransform tangfuru_Tf; //�̹��� ((�����ϱ�))

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
            }
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

        //�̹��� flip
        fruit_Tf = slots[potInventoryNum].GetComponent<RectTransform>();
        tangfuru_Tf = tangfuruSlots[potInventoryNum].GetComponent<RectTransform>();
        PotTangfuruImgFlip(); //���� �������� �������� ((�����ϱ�))

    }


    void PotTangfuruImgFlip() //���� ��� ���ķ簡 �����¿찡 �������� flip
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
        //������ ���� ��ġ ����
        potInventoryNum = Random.Range(0, slots.Length);
        Debug.Log("������ġ �������õ�. ���� ��ġ: " + potInventoryNum);
    }


}
