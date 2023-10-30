using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ObjectFruit : MonoBehaviour, IObjectFruit
{
    [Header("����")]
    public Fruit fruit;
    [Header("���� �̹���")]
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
