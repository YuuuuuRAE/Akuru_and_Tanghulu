using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public List<Fruit> fruits; //������ ���� ���� ����Ʈ 

    public float akuruMakingTime; //����� ���� �ð�
    //public Text timeText;
    
    public Slider akuruSlider; //����� ���� ���� �����̴�

    Animator anim;
    

    public bool isMaking;

    [Header("����")]
    public PotInventory potInventory; // ����

    [Header("�������� �ε��� ��ȣ")]
    public int index;

    UnlockFreezer unlockFreezer;
    public bool isAkuruWorking;


    private void Start()
    {
        //timeText = GameObject.Find(name: "SliderText").GetComponent<Text>();
        akuruSlider = GameObject.Find(name: "AkuruSlider").GetComponent<Slider>();
        potInventory = FindAnyObjectByType<PotInventory>();
        unlockFreezer = FindAnyObjectByType<UnlockFreezer>();
        anim = GetComponent<Animator>();
        

        akuruMakingTime = 0;
        isMaking = false;
        isAkuruWorking = false;
        index = 0;

    }

    void Update()
    {
        
        if (!isMaking && !potInventory.isPotFull )
        {

            RandomSelectTangfuru();
            anim.SetBool("isMakingTfr", false);
            isMaking = true;

        }
        else if(isMaking && !potInventory.isPotFull)
        {

            if (GameManager.instance.fruitNumList[index] > 0) // ���õ� ������ ������ ������
            {
                AkuruMakingTangfuru();
            }
            


        }
        
        
    }

    //���� ���� �ε��� ����
    void RandomSelectTangfuru() 
    {
        int fruitNum = 0;
        int nullFirstFruit = 0;
        for (int i = 0 ; i < GameManager.instance.fruit_FirstMaking.Count ; i++)//�������� ��ư �˻�
        {
            if(GameManager.instance.fruit_FirstMaking[i] == true)
            {
                index = i;
            }
            else { nullFirstFruit++; } //���������� ���õ��� ����

            
        }

        //����� �رݵ��� ���ķ� ���� ���� ����
        if (nullFirstFruit >= 5)//���� ������ ���õ��� �ʾҴٸ�
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                if (GameManager.instance.lockFreezer[i] == false)
                {
                    fruitNum = i + 1;
                    break;
                }
                else if (GameManager.instance.lockFreezer[3] == true)
                {
                    fruitNum = 3 + 1;
                    break;
                }
            }

            //������ ���ϼ���
            if (fruitNum == 0)
            {
                index = 0;
            }
            else
            {
                index = Random.Range(0, fruitNum);
            }
        }
        

        


    }
    void AkuruMakingTangfuru() //����� ���� ����
    {
        isAkuruWorking = true;
        akuruMakingTime += Time.deltaTime;
        //timeText.text = Mathf.FloorToInt(akuruMakingTime).ToString() + " S";
        akuruSlider.maxValue = fruits[index].making_time;
        akuruSlider.value = akuruMakingTime;
        anim.SetBool("isMakingTfr", true);

        if (akuruMakingTime >= fruits[index].making_time)
        {
            GoToPot();
            GameManager.instance.fruitNumList[index] -= 1;
            akuruMakingTime = 0;
            isMaking = false;
            isAkuruWorking = false;
        }
    }

    //�ۼ���
    void GoToPot()
    {
        if (!potInventory.isPotFull) //�����κ��丮�� ���� �ʾҴٸ�
        {
            potInventory.AddFruit(fruits[index]);
            //����� �� �����κ��丮�� ������ �־� �ش� 
        }
        

    }

    
}
