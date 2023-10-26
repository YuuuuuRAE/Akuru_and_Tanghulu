using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Fruit> fruits; //과일을 담을 리스트 

    public float akuruMakingTime;
    public Text timeText;
    
    public Slider akuruSlider;
    float sliderMax;
    float sliderNow;

    public bool isMaking;

    [Header("냄비")]
    public PotInventory potInventory; // 냄비

    [Header("랜덤과일 인덱스 번호")]
    public int i; 



    private void Start()
    {
        timeText = GameObject.Find(name: "SliderText").GetComponent<Text>();
        akuruSlider = GameObject.Find(name: "AkuruSlider").GetComponent<Slider>();
        potInventory = FindAnyObjectByType<PotInventory>();

        akuruMakingTime = 0;
        isMaking = false;
        i = 0;

    }

    void Update()
    {
        if (!isMaking && !potInventory.isPotFull)
        {
            akuruSlider.gameObject.SetActive(true);
            RandomSelectTangfuru();
            isMaking = true;
        }
        else if(isMaking && !potInventory.isPotFull)
        {
            AkuruMakingTangfuru();

        }
        else if (potInventory.isPotFull)
        {
            Debug.Log("냄비가 가득참");
            akuruSlider.gameObject.SetActive(false);
        }
    }

    //랜덤 과일 인덱스 선택
    public void RandomSelectTangfuru() 
    {
        //랜덤한 과일선택
        i = Random.Range(0, fruits.Count);
        Debug.Log("랜덤으로 과일이 선택되었습니다. 현재 손질중인 과일: " + fruits[i].name);


    }
    void AkuruMakingTangfuru() //아쿠루 과일 손질
    {
        akuruMakingTime += Time.deltaTime;
        timeText.text = Mathf.FloorToInt(akuruMakingTime).ToString() + " S";
        akuruSlider.maxValue = fruits[i].making_time;
        akuruSlider.value = akuruMakingTime;

        if (akuruMakingTime >= fruits[i].making_time)
        {
            GoToPot();
            Debug.Log("손질완료 / 걸린 손질시간" + fruits[i].making_time);
            akuruMakingTime = 0;
            isMaking = false;
        }
    }

    //작성중
    void GoToPot()
    {
        //potInventory.AddFruit(fruits[i]);


        if (potInventory.fruits.Count <= potInventory.slots.Length) //냄비인벤토리가 차지 않았다면
        {
            Debug.Log("냄비로 이동" + fruits[i]);
            potInventory.AddFruit(fruits[i]);
            //만들어 둔 냄비인벤토리에 과일을 넣어 준다 
        }
        else
        {
            Debug.Log("냄비 가득참");
        }

    }

    
}
