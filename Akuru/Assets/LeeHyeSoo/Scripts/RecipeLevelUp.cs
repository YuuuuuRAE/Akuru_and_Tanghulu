using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeLevelUp : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ����Ʈ 

    public Image tangfuruImage;

    [Header("������ ������")]
    public Text tangfuruLvUpNameText;
    public Text rcpLevelText;
    public Text priceText;
    public Text rqQuantityText;
    public Text rqcoinText;
    public Text saleTangfuruNumText;

    [Header("���ۼ��� �����̴�")]
    public Slider rqQuantitySlider;

    public int selectTangfuru; //���õ� ���� ������ �ε���
    GameObject clickObject;

    public int rcpLevel_UP; //���ķ� ����
    public int price_UP; //= �ش� ������ ���� �޼� �� �Ǹżҿ����� ���ķ� �Ǹ� ����
    public int exp_UP; //= �ش� ������ ������ �� ���ķ� ���۽� ����ġ
    public int rqQuantity_UP; //���� ������ �������� �ϱ� ���� �ʿ� ���� ����

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

    void SaveInFruit() //������Ʈ ���� ���Ͽ� �����ϱ�
    {
        fruits[selectTangfuru].rcpLevel = rcpLevel_UP;
        fruits[selectTangfuru].price = price_UP;
        fruits[selectTangfuru].exp = exp_UP;
        fruits[selectTangfuru].rqQuantity = rqQuantity_UP;
        fruits[selectTangfuru].rqCoin = rqCoin_UP;
        fruits[selectTangfuru].rqRuby = rqRuby_UP;
    }


    void RecipeLevelUpPopUptext() //������ ������ �˾�â �⺻ ���� 
    {
        tangfuruImage.sprite = fruits[selectTangfuru].tangfuruRcpLvUpImage;
        tangfuruLvUpNameText.text = fruits[selectTangfuru].fruitName + " ���ķ�";
        rcpLevelText.text = rcpLevel_UP.ToString(); //����
        priceText.text = price_UP.ToString(); // �ǸŰ���
        saleTangfuruNumText.text = fruits[selectTangfuru].saleTangfuruNum.ToString(); // �����Ǹ�Ƚ��
        rqQuantityText.text = fruits[selectTangfuru].rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = rqPay + "     ";
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
                Debug.Log("������ �����մϴ�");
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
            rqRuby_UP = 1; //���� �ٲ� ((�����ϱ�))
            rqPay = rqRuby_UP;

        }
    }



}
