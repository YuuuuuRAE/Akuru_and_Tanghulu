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

    public GameObject Spark; //�� �ڶ��� �� ��Ÿ�� ����ũ
    //��������Ʈ�� ��� �Ŀ� ���ϴµ� �ɸ��� �ð� ������� ����� �� �ܰ踦 ��������

    public bool isGrowing = false;
    public bool GrowingStart = false;
    public bool isGathering = true;
    private int index = 0;

   

    public void SetUp(GrowFruitData fruitdata)
    {
        GrowingStart = true; //�¾��� �ȴٸ� isGrowing�� true�� ��ȯ
        isGathering = false;

        FruitsName = fruitdata.FruitsName;
        flowerImage.sprite = fruitdata.flowerIcon;
        MidImage.sprite = fruitdata.MidIcon;
        FinImage.sprite = fruitdata.FinIcon;

        //�迭�� �Ҵ�
        sprites[0] = flowerImage.sprite;
        sprites[1] = MidImage.sprite;
        sprites[2] = FinImage.sprite;
        
        //������ �ð� ���� �Ҵ�
        None_Time = fruitdata.None_Time;
        Flower_Time = fruitdata.Flower_Time;
        Min_Time = fruitdata.Mid_Time;

        //�迭�� �Ҵ�
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
                //None Time�� ������ �� ���İ��� 255�� �ٲٰ� �� �̹����� ����
                Color color = CurrentImage.color;
                if (color.a == 0)
                {
                    color.a = 255;
                    CurrentImage.color = color;
                }

                CurrentImage.sprite = sprites[index];

                //�ʱ�ȭ
                index++;
                if (index == 3)
                {
                    index = 0;
                    Spark.SetActive(true);
                    CurrentImage.GetComponent<Button>().interactable = true; //���� �� �ְ� ����
                    isGrowing = false;
                }

                currentTime = 0;
            }
        }
    }
    
    //���� ���� �Լ�
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

            //�ش��ϴ� ���� �������� FruitsCount ����
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
