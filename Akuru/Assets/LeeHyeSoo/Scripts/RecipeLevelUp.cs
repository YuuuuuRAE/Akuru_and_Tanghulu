using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeLevelUp : MonoBehaviour
{
    public Image tangfuruImage;

    [Header("레시피 레벨업")]
    public Text rcpLevelText;
    public Text priceText;
    public Text rqQuantityText;
    public Text rqcoinText;
    public Text saleTangfuruNumText;

    public Slider rqQuantitySlider;

    int rcpLevel_UP; //탕후루 레벨
    int price_UP; //= 해당 레시피 레벨 달성 시 판매소에서의 탕후루 판매 가격
    //int exp_UP; //= 해당 레시피 레벨일 때 탕후루 제작시 경험치
    int rqQuantity_UP; //다음 레벨로 레벨업을 하기 위한 필요 제작 수량
    int rqCoin_UP; // 레벨업에 필요한 재화
    //int rqRuby_UP; // 레벨업에 필요한 재화

    int rqQuantityNow; //현재 제작 수량
    int saleTangfuruNum; // 누적 탕후루 판매 갯수

    private void Start()
    {
        rcpLevel_UP = 1; 
        price_UP = 20;
        //exp_UP = 1;
        rqQuantity_UP = 30;
        rqCoin_UP = 500;

        rqQuantityNow = 15;
        saleTangfuruNum = 00;
    }

    private void Update()
    {
        
        RecipeLevelUpPopUptext();
        QuantitySlider();
    }

    void RecipeLevelUpPopUptext() //레시피 레벨업 팝업창 기본 세팅 
    {
        rcpLevelText.text = "Lv." + rcpLevel_UP;
        priceText.text = "판매 가격    " + price_UP;
        saleTangfuruNumText.text = "누적 판매 횟수    " + saleTangfuruNum;
        rqQuantityText.text = rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = "레벨업\n" + rqCoin_UP;
    }

    void QuantitySlider() //슬라이더 제어
    {
        rqQuantitySlider.maxValue = rqQuantity_UP;
        rqQuantitySlider.value = rqQuantityNow;
    }

    //void IsLevelUp()
    //{
    //    if(rqQuantityNow == rqQuantity_UP)
    //    {
    //        rcpLevel_UP++;
    //        rqQuantityNow = 0;
    //    }
    //}

    //void RCPLevelUp()
    //{
    //    if(rcpLevel_UP == 2)
    //    {
    //        price_UP = 25;
    //        exp_UP = 1;
    //        rqQuantity_UP = 60;
    //        rqCoin_UP = 1000;
    //    }
    //    else if (rcpLevel_UP == 3)
    //    {
    //        price_UP = 30;
    //        exp_UP = 1;
    //        rqQuantity_UP = 90;
    //        rqCoin_UP = 1500;
    //    }
    //    else if (rcpLevel_UP == 4)
    //    {
    //        price_UP = 35;
    //        exp_UP = 1;
    //        rqQuantity_UP = 120;
    //        rqCoin_UP = 2000;
    //    }
    //    else if (rcpLevel_UP == 5)
    //    {
    //        price_UP = 40;
    //        exp_UP = 2;
    //        rqQuantity_UP = 150;
    //        //rqCoin_UP = rqRuby_UP; //루비로 바뀜 ((수정하기))
    //    }
    //}



}
