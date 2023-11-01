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
    //int exp_UP; //= �ش� ������ ������ �� ���ķ� ���۽� ����ġ
    int rqQuantity_UP; //���� ������ �������� �ϱ� ���� �ʿ� ���� ����
    int rqCoin_UP; // �������� �ʿ��� ����
                   //int rqRuby_UP; // �������� �ʿ��� ���


    private void Start()
    {
        //for (int i = 0; i < fruits.Count; i++) //���� 1 �ʱ�ȭ
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

        Debug.Log("���õ� ������:" + selectTangfuru);
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


    void RecipeLevelUpPopUptext() //������ ������ �˾�â �⺻ ���� 
    {
        rcpLevelText.text = "Lv." + rcpLevel_UP;
        priceText.text = "�Ǹ� ����    " + price_UP;
        saleTangfuruNumText.text = "���� �Ǹ� Ƚ��    " + fruits[selectTangfuru].saleTangfuruNum;
        rqQuantityText.text = fruits[selectTangfuru].rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = "������\n" + rqCoin_UP;
    }

    void QuantitySlider() //�����̴� ����
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
            //rqCoin_UP = rqRuby_UP; //���� �ٲ� ((�����ϱ�))
        }
    }



}
