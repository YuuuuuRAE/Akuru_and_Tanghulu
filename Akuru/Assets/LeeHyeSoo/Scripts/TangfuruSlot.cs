using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TangfuruSlot : MonoBehaviour
{
    [SerializeField] public Image image;


    private Fruit __fruit; //이미지 컴포넌트 담을 곳
    public Fruit fruit
    {
        get { return __fruit; } //슬롯의 fruit정보를 넘겨줄 때
        set
        {
            __fruit = value; //fruit에 들어오는 정보의 값은 _fruit에 저장됩니다.
            if (__fruit != null)
            {
                
                image.sprite = fruit.tangfuruImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
