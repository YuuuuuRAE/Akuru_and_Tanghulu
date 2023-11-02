using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TangfuruGoToFreezer : MonoBehaviour
{
    GraphicRaycaster raycaster; //canvas�� �׷��ȷ����ɽ���
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    FreezeTangfuru freezeTangfuru;
    RecipeLevelUp recipeLevelUp; //���ķ� ���ۼ��� ������ ���
    //int tangfuruNum; //���õ� ���ķ� �ε��� ����

    Player player;

    public GameObject potCompleteFruitsImg; //�����Ϸ�� ���� �̹���

    public GameObject hitObj1;
    public GameObject hitObj2;

    public Image ClickFruitImg;

    //public int tangfuruInFreezer;
    int FreezerNum = 5; // ����� ����

    private void Awake()
    {
        raycaster = GameObject.Find(name: "AT_200Canvas").GetComponent<GraphicRaycaster>();
        eventSystem = FindAnyObjectByType<EventSystem>();
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();
        recipeLevelUp = FindAnyObjectByType<RecipeLevelUp>();
        player = GetComponent<Player>();
    }
    void Start()
    {
        potCompleteFruitsImg.SetActive(false);
    }

    private void Update()
    {


        ////((�����۾���))
        if (Input.GetMouseButtonDown(0))
        {
            //�̺�Ʈ �ý����� �������̺�Ʈ�����Ϳ� ��
            pointerEventData = new PointerEventData(eventSystem);

            //���콺 �������� ������ �̺�Ʈ�����������ǿ� ��
            pointerEventData.position = Input.mousePosition;

            //����ĳ��Ʈ ����Ʈ ����
            List<RaycastResult> results = new List<RaycastResult>();

            //����ĳ��Ʈ ���
            raycaster.Raycast(pointerEventData, results);

            Image hitObj1Img;
            Color ImgClear = new Color(1, 1, 1, 0);

            //�ش��� ù ��° ��ü Ȯ��
            if (results[0].gameObject != null && results[0].gameObject.tag == "Tangfuru")
            {
                hitObj1 = results[0].gameObject;
                hitObj1Img = hitObj1.GetComponent<Image>();
                if (hitObj1Img.color != ImgClear)
                {
                    ClickFruitImg = hitObj1.GetComponent<Image>();
                    potCompleteFruitsImg.SetActive(true);
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            potCompleteFruitsImg.SetActive(false);

            //�̺�Ʈ �ý����� �������̺�Ʈ�����Ϳ� ��
            pointerEventData = new PointerEventData(eventSystem);

            //���콺 �������� ������ �̺�Ʈ�����������ǿ� ��
            pointerEventData.position = Input.mousePosition;

            //����ĳ��Ʈ ����Ʈ ����
            List<RaycastResult> results = new List<RaycastResult>();

            //����ĳ��Ʈ ���
            raycaster.Raycast(pointerEventData, results);

            //�ش��� ù ��° ��ü Ȯ��

            if (results[0].gameObject != null && results[0].gameObject.tag == "Freezer")
            {
                hitObj2 = results[0].gameObject;
                Debug.Log("�����ҿ� ���ķ縦 ���� / �浹�� ������:" + results[0].gameObject.name);
                for (int i = 0; i < FreezerNum; i++)
                {
                    if (results[0].gameObject.name == "EmptyFreezerImage (" + i + ")") //�浹�� ������ �ε���
                    {
                        freezeTangfuru.FullFreezer(i); //�ش� ������ á������ ��ȯ
                        freezeTangfuru.tangfuruNumInFreezerNow[i]++;
                        for (int j = 0; j < 20; j++) 
                        {
                            if (hitObj1.name == "TangfuruImage (" + j + ")")
                            {
                                Debug.Log("��� ���ķ糿����ġ: " + (hitObj1.name));
                                Image image = hitObj1.GetComponent<Image>(); 
                                Debug.Log("��� ���ķ�����: " + image.sprite);

                                for (int k = 0; k < player.fruits.Count; k++)
                                {
                                    if (image.sprite.name == player.fruits[k].tangfuruImage.name)
                                    {
                                        player.fruits[k].rqQuantityNow++;
                                        
                                        Debug.Log("�������� / ���� ���ۼ���: "
                                            + player.fruits[k].rqQuantityNow);
                                    }
                                }
                                
                                //player.fruits[j].rqQuantityNow++;
                                //Debug.Log("�������� / ���� ���ۼ���: "
                                //    + player.fruits[j].rqQuantityNow++);
                            }
                        }
                        
                        

                    }
                }

                
            }
        }
    }
}
