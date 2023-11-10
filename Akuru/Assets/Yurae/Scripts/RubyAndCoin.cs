using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class RubyAndCoin : MonoBehaviour
{
    [SerializeField]
    private int RubyCount = 0; 
    [SerializeField]
    private int CoinCount = 0;

    [SerializeField]
    private Text RubyQuantity;
    [SerializeField]
    public Text CoinQuantity;

    // Update is called once per frame
    void Update()
    {


        //�ؽ�Ʈ ���� �Լ�
        MakeRubyText();
        MakeCoinText();

        if (Input.GetKeyDown(KeyCode.C))
        {
            GainCoin();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GainRuby();
        }
    }

    // ���ڸ� õ ���� ���� ��ȣ�� �ִ� ���ڿ��� ����ȭ
    private string FormatNumber(float number)
    {
        return string.Format("{0:N0}", number);

    }

    private void GainRuby()
    {
        GameManager.instance.currentRuby += RubyCount;
    }

    private void GainCoin()
    {
       GameManager.instance.currentCoin += CoinCount;
    }

    private void MakeRubyText()
    {
        RubyQuantity.text = FormatNumber(GameManager.instance.currentRuby);
    }

    private void MakeCoinText()
    {
        CoinQuantity.text = FormatNumber(GameManager.instance.currentCoin);
    }
}
