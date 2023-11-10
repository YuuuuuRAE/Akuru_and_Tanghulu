using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeLevelUp : MonoBehaviour
{
    public List<Fruit> fruits; //과일을 담을 리스트 

    public Image tangfuruImage;

    [Header("레시피 레벨업")]
    public Text tangfuruLvUpNameText;
    public Text rcpLevelText;
    public Text priceText;
    public Text rqQuantityText;
    public Text rqcoinText;
    public Text saleTangfuruNumText;

    [Header("제작수량 슬라이더")]
    public Slider rqQuantitySlider;

    public int selectTangfuru; //선택된 과일 레시피 인덱스
    GameObject clickObject;

    public int rcpLevel_UP; //탕후루 레벨
    public int price_UP; //= 해당 레시피 레벨 달성 시 판매소에서의 탕후루 판매 가격
    public int exp_UP; //= 해당 레시피 레벨일 때 탕후루 제작시 경험치
    public int rqQuantity_UP; //다음 레벨로 레벨업을 하기 위한 필요 제작 수량

    int rqPay;
    int rqCoin_UP; // 레벨업에 필요한 코인
    int rqRuby_UP; // 레벨업에 필요한 루비

    
    private void Start()
    {
        SelectRecipe();
        rqPay = rqCoin_UP;
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

    public void SelectRecipe()
    {
        tangfuruImage.sprite = fruits[selectTangfuru].tangfuruRcpLvUpImage;
        rcpLevel_UP = fruits[selectTangfuru].rcpLevel;
        price_UP = fruits[selectTangfuru].price;
        exp_UP = fruits[selectTangfuru].exp;
        rqQuantity_UP = fruits[selectTangfuru].rqQuantity;
        rqCoin_UP = fruits[selectTangfuru].rqCoin;
        rqRuby_UP = fruits[selectTangfuru].rqRuby;

        
    }

    void SaveInFruit() //업데이트 정보 과일에 저장하기
    {
        fruits[selectTangfuru].rcpLevel = rcpLevel_UP;
        fruits[selectTangfuru].price = price_UP;
        fruits[selectTangfuru].exp = exp_UP;
        fruits[selectTangfuru].rqQuantity = rqQuantity_UP;
        fruits[selectTangfuru].rqCoin = rqCoin_UP;
        fruits[selectTangfuru].rqRuby = rqRuby_UP;
    }


    void RecipeLevelUpPopUptext() //레시피 레벨업 팝업창 기본 세팅 
    {
        tangfuruImage.sprite = fruits[selectTangfuru].tangfuruRcpLvUpImage;
        tangfuruLvUpNameText.text = fruits[selectTangfuru].fruitName + " 탕후루";
        rcpLevelText.text = rcpLevel_UP.ToString(); //레벨
        priceText.text = price_UP.ToString(); // 판매가격
        saleTangfuruNumText.text = fruits[selectTangfuru].saleTangfuruNum.ToString(); // 누적판매횟수
        rqQuantityText.text = fruits[selectTangfuru].rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = rqPay + "     ";
    }

    void QuantitySlider() //슬라이더 제어
    {
        rqQuantitySlider.maxValue = rqQuantity_UP;
        rqQuantitySlider.value = fruits[selectTangfuru].rqQuantityNow;
    }

    public void ClickRecipeLevelUp() //레시피 레벨업 버튼
    {
        if (fruits[selectTangfuru].rqQuantityNow == rqQuantity_UP && rcpLevel_UP < 5)
        {
            RCPLevelUp();
            if (GameManager.instance.currentCoin > rqPay)
            {
                if (rcpLevel_UP < 4)
                {
                    GameManager.instance.currentCoin -= rqCoin_UP;
                }
                else
                {
                    GameManager.instance.currentRuby -= rqRuby_UP;
                }
                rcpLevel_UP++;
                RCPLevelUp();
                SaveInFruit();
            }
            else
            {
                Debug.Log("코인이 부족합니다");
            }
                
        }
    }

    void RCPLevelUp()
    {
        if(rcpLevel_UP == 1)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 20;
            exp_UP = 1;
            rqQuantity_UP = 30;
            rqCoin_UP = 500;
            rqPay = rqCoin_UP;

            
        }
        else if (rcpLevel_UP == 2)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 25;
            exp_UP = 1;
            rqQuantity_UP = 60;
            rqCoin_UP = 1000;
            rqPay = rqCoin_UP;

        }
        else if (rcpLevel_UP == 3)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 30;
            exp_UP = 1;
            rqQuantity_UP = 90;
            rqCoin_UP = 1500;
            rqPay = rqCoin_UP;

        }
        else if (rcpLevel_UP == 4)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;


            price_UP = 35;
            exp_UP = 1;
            rqQuantity_UP = 120;
            rqCoin_UP = 2000;
            rqPay = rqCoin_UP;

        }
        else if (rcpLevel_UP == 5)
        {
            fruits[selectTangfuru].saleTangfuruNum += fruits[selectTangfuru].rqQuantityNow;
            fruits[selectTangfuru].rqQuantityNow = 0;

            price_UP = 40;
            exp_UP = 2;
            rqQuantity_UP = 150;
            rqRuby_UP = 1; //루비로 바뀜 ((수정하기))
            rqPay = rqRuby_UP;

        }
    }



}
