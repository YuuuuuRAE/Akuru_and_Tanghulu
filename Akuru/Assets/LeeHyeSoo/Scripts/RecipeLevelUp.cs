using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeLevelUp : MonoBehaviour
{
    public Image tangfuruImage;

    [Header("������ ������")]
    public Text rcpLevelText;
    public Text priceText;
    public Text rqQuantityText;
    public Text rqcoinText;
    public Text saleTangfuruNumText;

    public Slider rqQuantitySlider;

    int rcpLevel_UP; //���ķ� ����
    int price_UP; //= �ش� ������ ���� �޼� �� �Ǹżҿ����� ���ķ� �Ǹ� ����
    //int exp_UP; //= �ش� ������ ������ �� ���ķ� ���۽� ����ġ
    int rqQuantity_UP; //���� ������ �������� �ϱ� ���� �ʿ� ���� ����
    int rqCoin_UP; // �������� �ʿ��� ��ȭ
    //int rqRuby_UP; // �������� �ʿ��� ��ȭ

    int rqQuantityNow; //���� ���� ����
    int saleTangfuruNum; // ���� ���ķ� �Ǹ� ����

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

    void RecipeLevelUpPopUptext() //������ ������ �˾�â �⺻ ���� 
    {
        rcpLevelText.text = "Lv." + rcpLevel_UP;
        priceText.text = "�Ǹ� ����    " + price_UP;
        saleTangfuruNumText.text = "���� �Ǹ� Ƚ��    " + saleTangfuruNum;
        rqQuantityText.text = rqQuantityNow + " /" + rqQuantity_UP;
        rqcoinText.text = "������\n" + rqCoin_UP;
    }

    void QuantitySlider() //�����̴� ����
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
    //        //rqCoin_UP = rqRuby_UP; //���� �ٲ� ((�����ϱ�))
    //    }
    //}



}
