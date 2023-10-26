using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ����Ʈ 

    public float akuruMakingTime;
    public Text timeText;
    
    public Slider akuruSlider;
    float sliderMax;
    float sliderNow;

    public bool isMaking;

    [Header("����")]
    public PotInventory potInventory; // ����

    [Header("�������� �ε��� ��ȣ")]
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
            Debug.Log("���� ������");
            akuruSlider.gameObject.SetActive(false);
        }
    }

    //���� ���� �ε��� ����
    public void RandomSelectTangfuru() 
    {
        //������ ���ϼ���
        i = Random.Range(0, fruits.Count);
        Debug.Log("�������� ������ ���õǾ����ϴ�. ���� �������� ����: " + fruits[i].name);


    }
    void AkuruMakingTangfuru() //����� ���� ����
    {
        akuruMakingTime += Time.deltaTime;
        timeText.text = Mathf.FloorToInt(akuruMakingTime).ToString() + " S";
        akuruSlider.maxValue = fruits[i].making_time;
        akuruSlider.value = akuruMakingTime;

        if (akuruMakingTime >= fruits[i].making_time)
        {
            GoToPot();
            Debug.Log("�����Ϸ� / �ɸ� �����ð�" + fruits[i].making_time);
            akuruMakingTime = 0;
            isMaking = false;
        }
    }

    //�ۼ���
    void GoToPot()
    {
        //potInventory.AddFruit(fruits[i]);


        if (potInventory.fruits.Count <= potInventory.slots.Length) //�����κ��丮�� ���� �ʾҴٸ�
        {
            Debug.Log("����� �̵�" + fruits[i]);
            potInventory.AddFruit(fruits[i]);
            //����� �� �����κ��丮�� ������ �־� �ش� 
        }
        else
        {
            Debug.Log("���� ������");
        }

    }

    
}
