using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeLevelUp : MonoBehaviour
{
    public List<Fruit> fruits; //과일을 담을 리스트 

    public Image tangfuruImage;

    [Header("레시피 레벨업")]
    public Text rcpLevelText;
    public Text priceText;
    public Text rqQuantityText;
    public Text rqcoinText;
    public Text saleTangfuruNumText;

    [Header("제작수량 슬라이더")]
    public Slider rqQuantitySlider;

    public int selectTangfuru; //선택된 과일 레시피 인덱스
    GameObject clickObject;

    int rcpLevel_UP; //탕후루 레벨
    int price_UP; //= 해당 레시피 레벨 달성 시 판매소에서의 탕후루 판매 가격
    //int exp_UP; //= 해당 레시피 레벨일 때 탕후루 제작시 경험치
    int rqQuantity_UP; //다음 레벨로 레벨업을 하기 위한 필요 제작 수량
    int rqCoin_UP; // 레벨업에 필요한 코인
                   //int rqRuby_UP; // 레벨업에 필요한 루비


    private void Start()
    {
        //for (int i = 0; i < fruits.Count; i++) //레벨 1 초기화
        //{
        //    fruits[i].rcpLevel = 1;
        //    fruits[i].price = 20;
        //    fruits[i].exp = 1;
        //    fruits[i].rqQuantity = 30;
        //    fruits[i].rqCoin = 500;
        //    fruits[i].rqRuby = 1;

        //    fruits[i].rqQuantityNow = 0;
        //    fruits[i].saleTangfuruNum = 0;
        //}
    }

    private void Update()
    {
        RecipeLevelUpPopUptext();
        QuantitySlider();
    }


    public void ClickWhatRecipe()
    {
        clickObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(clickObject);
        for (int i = 0; i < fruits.Count; i++)
        {
            if (clickObject.name == "Button (" + i + ")")
            {
                selectTangfuru = i;
            }
        }

        Debug.Log("선택된 레시피:" + selectTangfuru);
        SelectRecipe();


    }

    void SelectRecipe()
    {
        tangfuruImage.sprite = fruits[selectTangfuru].tangfuruImage;
        rcpLevel_UP = fruits[selectTangfuru].rcpLevel;
        price_UP = fruits[selectTangfuru].price;
        //exp_UP = fruits[selectTangfuru].exp;
        rqQuantity_UP = fruits[selectTangfuru].rqQuantity;
        rqCoin_UP = fruits[selectTangfuru].rqCoin;
        //rqRuby_UP = fruits[selectTangfuru].rqRuby;

        
    }


    void RecipeLevelUpPopUptext() //레시피 레벨업 팝업창 기본 세팅 
    {
        rcpLevelText.text = "Lv." + rcpLevel_UP;
        priceText.text = "판매 가격    " + price_UP;
        saleTangfuruNumText.text = "누적 판매 횟수    " + fruits[selectTangfuru].saleTangfuruNum;
        rqQuantityText.text = fruits[selectTangfuru].rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = "레벨업\n" + rqCoin_UP;
    }

    void QuantitySlider() //슬라이더 제어
    {
        rqQuantitySlider.maxValue = rqQuantity_UP;
        rqQuantitySlider.value = fruits[selectTangfuru].rqQuantityNow;
    }

    public void ClickRecipeLevelUp()
    {
        if (fruits[selectTangfuru].rqQuantityNow == rqQuantity_UP && rcpLevel_UP < 5)
        {
            rcpLevel_UP++;
            fruits[selectTangfuru].rcpLevel = rcpLevel_UP;
            RCPLevelUp();


        }


    }

    void RCPLevelUp()
    {
        if (rcpLevel_UP == 2)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 25;
            //exp_UP = 1;
            rqQuantity_UP = 60;
            rqCoin_UP = 1000;
        }
        else if (rcpLevel_UP == 3)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 30;
            //exp_UP = 1;
            rqQuantity_UP = 90;
            rqCoin_UP = 1500;
        }
        else if (rcpLevel_UP == 4)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;


            price_UP = 35;
            //exp_UP = 1;
            rqQuantity_UP = 120;
            rqCoin_UP = 2000;
        }
        else if (rcpLevel_UP == 5)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 40;
            //exp_UP = 2;
            rqQuantity_UP = 150;
            //rqCoin_UP = rqRuby_UP; //루비로 바뀜 ((수정하기))
        }
    }



}
