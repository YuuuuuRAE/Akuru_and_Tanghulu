using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowFruit : MonoBehaviour
{
    [SerializeField]
    private string FruitsName;
    [SerializeField]
    private Image flowerImage;
    [SerializeField]
    private Image MidImage;
    [SerializeField]
    private Image FinImage;

    public void SetUp(GrowFruitData fruitdata)
    {
        FruitsName = fruitdata.FruitsName;
        flowerImage.sprite = fruitdata.flowerIcon;
        MidImage.sprite = fruitdata.MidIcon;
        FinImage.sprite = fruitdata.FinIcon;
    }
    
}
