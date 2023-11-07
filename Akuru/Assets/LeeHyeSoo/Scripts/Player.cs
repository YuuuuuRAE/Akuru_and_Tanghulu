using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ���� ����Ʈ 

    public float akuruMakingTime; //����� ���� �ð�
    public Text timeText;
    
    public Slider akuruSlider; //����� ���� ���� �����̴�

    Animator anim;
    

    public bool isMaking;

    [Header("����")]
    public PotInventory potInventory; // ����

    [Header("�������� �ε��� ��ȣ")]
    public int i;

    UnlockFreezer unlockFreezer;



    private void Start()
    {
        timeText = GameObject.Find(name: "SliderText").GetComponent<Text>();
        akuruSlider = GameObject.Find(name: "AkuruSlider").GetComponent<Slider>();
        potInventory = FindAnyObjectByType<PotInventory>();
        unlockFreezer = FindAnyObjectByType<UnlockFreezer>();
        anim = GetComponent<Animator>();

        akuruMakingTime = 0;
        isMaking = false;
        i = 0;

    }

    void Update()
    {
        
        if (!isMaking && !potInventory.isPotFull)
        {

            RandomSelectTangfuru();
            isMaking = true;

        }
        else if(isMaking && !potInventory.isPotFull)
        {
            AkuruMakingTangfuru();
            anim.SetBool("isMakingTfr",true);

        }
        else
        {
            anim.SetBool("isMakingTfr", false);
        }
        
    }

    //���� ���� �ε��� ����
    void RandomSelectTangfuru() 
    {
        //����� �رݵ��� ���ķ� ���� ���� ����
        int fruitNum = 0;
        for (int i = 0; i < fruits.Count; i++)
        {
            if (unlockFreezer.lockFreezer[i] == false)
            {
                fruitNum = i + 1;
                break;
            }
            else if (unlockFreezer.lockFreezer[3] == true)
            {
                fruitNum = 3 + 1;
                break;
            }
        }



        //������ ���ϼ���
        if (fruitNum == 0)
        {
            i = 0;
        }
        else
        {
            i = Random.Range(0, fruitNum);
        }
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
            
            Debug.Log("�����Ϸ�");
            GoToPot();
            akuruMakingTime = 0;
            isMaking = false;
        }
    }

    //�ۼ���
    void GoToPot()
    {
        if (!potInventory.isPotFull) //�����κ��丮�� ���� �ʾҴٸ�
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
