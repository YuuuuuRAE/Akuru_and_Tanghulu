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
    public bool isPotFull = false;

#if UNITY_EDITOR
    private void OnValidate() //OnValidate�� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ����
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
        //selectNum = player.RandomSelectTangfuru();

        FreshSlot(); //������ ���۵Ǹ� fruit�� ����ִ� �������� potinventoy�� �־��ش� 
    }

    public void FreshSlot() //�������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ���
    {
        int i = 0;
        for (; i < fruits.Count && i < slots.Length; i++) // i�� ���� items�� slots �� ���� �� ���� �۾ƾ߸�
        {
            slots[i].fruit = fruits[i];
        }
        for (; i < slots.Length; i++) 
        {
            slots[i].fruit = null;

            //slot�� �������� �� �����ϰ� �� �Ŀ��� slot�� ���� �ִٸ�
            //���� for���� ����Ǿ� �� ���Ե��� ��� null ó��
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
            print("������ ���� �� �ֽ��ϴ�.");
            isPotFull = true;
        }
    }

    
}
