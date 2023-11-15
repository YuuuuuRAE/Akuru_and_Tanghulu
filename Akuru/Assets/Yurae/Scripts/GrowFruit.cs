using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
    [SerializeField]
    private Image CurrentImage;
    [SerializeField]
    private float None_Time;
    [SerializeField]
    private float Flower_Time;
    [SerializeField]
    private float Min_Time;

    private Sprite[] sprites = new Sprite[3];
    private float[] times = new float[3];

    [SerializeField]
    private float currentTime;

    public ProductionPlant productionPlant;

    public GameObject Spark; //다 자랐을 때 나타날 스파크
    //스프라이트의 경우 후에 변하는데 걸리는 시간 변경들을 고려해 각 단계를 나눠놓음

    public bool isGrowing = false;
    public bool GrowingStart = false;
    public bool isGathering = true;
    private int index = 0;

   

    public void SetUp(GrowFruitData fruitdata)
    {
        GrowingStart = true; //셋업이 된다면 isGrowing을 true로 변환
        isGathering = false;

        FruitsName = fruitdata.FruitsName;
        flowerImage.sprite = fruitdata.flowerIcon;
        MidImage.sprite = fruitdata.MidIcon;
        FinImage.sprite = fruitdata.FinIcon;

        //배열에 할당
        sprites[0] = flowerImage.sprite;
        sprites[1] = MidImage.sprite;
        sprites[2] = FinImage.sprite;
        
        //각각의 시간 구간 할당
        None_Time = fruitdata.None_Time;
        Flower_Time = fruitdata.Flower_Time;
        Min_Time = fruitdata.Mid_Time;

        //배열에 할당
        times[0] = None_Time;
        times[1] = Flower_Time;
        times[2] = Min_Time;
    }

    void Update()
    {
        if (GrowingStart)
        {
            GrowingStart = false;
            isGrowing = true;
        }

        if (isGrowing)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= times[index])
            {
                //None Time이 지났을 때 알파값을 255로 바꾸고 꽃 이미지로 변경
                Color color = CurrentImage.color;
                if (color.a == 0)
                {
                    color.a = 255;
                    CurrentImage.color = color;
                }

                CurrentImage.sprite = sprites[index];

                //초기화
                index++;
                if (index == 3)
                {
                    index = 0;
                    Spark.SetActive(true);
                    CurrentImage.GetComponent<Button>().interactable = true; //누를 수 있게 변경
                    isGrowing = false;
                }

                currentTime = 0;
            }
        }
    }
    
    //성장 가속 함수
    public void GrowAccel()
    {
        if (isGrowing)
        currentTime += 3f;
    }

    public void Gathering()
    {
        if(isGathering == false)
        {
            isGathering = true;
            CurrentImage.GetComponent<Button>().interactable = false;

            Spark.SetActive(false);

            Color color = CurrentImage.color;
            color.a = 0;
            CurrentImage.color = color;

            //해당하는 과일 데이터의 FruitsCount 증가
            for (int i = 0; i < productionPlant.growFruitDatas.Length; i++)
            {
                if(FruitsName == productionPlant.growFruitDatas[i].FruitsName)
                {
                    GameManager.instance.fruitNumList[i]++;
                }
            }
        }
    }


}
