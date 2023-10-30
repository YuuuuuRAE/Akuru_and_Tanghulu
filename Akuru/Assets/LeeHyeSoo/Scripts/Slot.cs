using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    

    private Fruit __fruit; //�̹��� ������Ʈ ���� ��
    public Fruit fruit
    {
        get { return __fruit; } //������ fruit������ �Ѱ��� ��
        set
        {
            __fruit = value; //fruit�� ������ ������ ���� _fruit�� ����˴ϴ�.
            if (__fruit != null)
            {
                image.sprite = fruit.fruitImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
            /* �� �κ��� �ٷ� �� �ڵ��� AddItem()�� FreshSlot() �Լ����� ���˴ϴ�. */
        }
    }
}
