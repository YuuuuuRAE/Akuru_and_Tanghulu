using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeLevelUp : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ����Ʈ 

    public Image tangfuruImage;

    [Header("������ ������")]
    public Text rcpLevelText;
    public Text priceText;
    public Text rqQuantityText;
    public Text rqcoinText;
    public Text saleTangfuruNumText;

    [Header("���ۼ��� �����̴�")]
    public Slider rqQuantitySlider;

    public int selectTangfuru; //���õ� ���� ������ �ε���
    GameObject clickObject;

    int rcpLevel_UP; //���ķ� ����
    int price_UP; //= �ش� ������ ���� �޼� �� �Ǹżҿ����� ���ķ� �Ǹ� ����
    int exp_UP; //= �ش� ������ ������ �� ���ķ� ���۽� ����ġ
    int rqQuantity_UP; //���� ������ �������� �ϱ� ���� �ʿ� ���� ����

    int rqPay;
    int rqCoin_UP; // �������� �ʿ��� ����
    int rqRuby_UP; // �������� �ʿ��� ���


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

        Debug.Log("���õ� ������:" + selectTangfuru);
        SelectRecipe();


    }

    void SelectRecipe()
    {
        tangfuruImage.sprite = fruits[selectTangfuru].tangfuruImage;
        rcpLevel_UP = fruits[selectTangfuru].rcpLevel;
        price_UP = fruits[selectTangfuru].price;
        exp_UP = fruits[selectTangfuru].exp;
        rqQuantity_UP = fruits[selectTangfuru].rqQuantity;
        rqCoin_UP = fruits[selectTangfuru].rqCoin;
        rqRuby_UP = fruits[selectTangfuru].rqRuby;

        
    }


    void RecipeLevelUpPopUptext() //������ ������ �˾�â �⺻ ���� 
    {
        rcpLevelText.text = "Lv." + rcpLevel_UP;
        priceText.text = "�Ǹ� ����    " + price_UP;
        saleTangfuruNumText.text = "���� �Ǹ� Ƚ��    " + fruits[selectTangfuru].saleTangfuruNum;
        rqQuantityText.text = fruits[selectTangfuru].rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = "������\n" + rqPay;
    }

    void QuantitySlider() //�����̴� ����
    {
        rqQuantitySlider.maxValue = rqQuantity_UP;
        rqQuantitySlider.value = fruits[selectTangfuru].rqQuantityNow;
    }

    public void ClickRecipeLevelUp() //������ ������ ��ư
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
            rqRuby_UP = 1; //���� �ٲ� ((�����ϱ�))
            rqPay = rqRuby_UP;
        }
    }



}
