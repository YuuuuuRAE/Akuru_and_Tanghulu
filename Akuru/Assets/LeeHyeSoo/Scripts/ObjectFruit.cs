using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ObjectFruit : MonoBehaviour, IObjectFruit
{
    [Header("과일")]
    public Fruit fruit;
    [Header("과일 이미지")]
    public Image fruitImage;

    void Awake()
    {
        fruitImage = GetComponent<Image>();
    }

    void Start()
    {
        fruitImage.sprite = fruit.fruitImage;
    }
    public Fruit ClickFruit()
    {
        return this.fruit;
    }


}
