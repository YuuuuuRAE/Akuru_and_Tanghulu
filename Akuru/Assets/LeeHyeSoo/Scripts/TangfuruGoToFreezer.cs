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
    //RecipeLevelUp recipeLevelUp; //���ķ� ���ۼ��� ������ ���
    PotInventory potInventory;
    int tangfuruNum; //���õ� ���ķ� �ε��� ����

    Player player;

    public GameObject potCompleteFruitsImg; //�����Ϸ�� ���� �̹���

    public GameObject hitObj1;
    public GameObject hitObj2;

    public Image ClickFruitImg; //�巡���� �� �巡�� �̹����� ���� ��

    //public int tangfuruInFreezer;
    int FreezerNum = 5; // ����� ����

    private void Awake()
    {
        raycaster = GameObject.Find(name: "AT_200Canvas").GetComponent<GraphicRaycaster>();
        eventSystem = FindAnyObjectByType<EventSystem>();
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();
        //recipeLevelUp = FindAnyObjectByType<RecipeLevelUp>();
        potInventory = FindAnyObjectByType<PotInventory>();
        player = GetComponent<Player>();
    }
    void Start()
    {
        potCompleteFruitsImg.SetActive(false);
    }

    private void Update()
    {
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
            if (results[0].gameObject != null && results[0].gameObject.tag == "Tangfuru" && hitObj2 == null)
            {
                hitObj1 = results[0].gameObject;
                hitObj1Img = hitObj1.GetComponent<Image>();
                if (hitObj1Img.color != ImgClear)
                {
                    Debug.LogWarning("Ŭ���� �Ⱥ������� ���ķ�" + hitObj1Img.name); //��) TangfuruImage (7)
                    for (int i = 0; i < potInventory.slots.Length; i++)
                    {
                        if (hitObj1Img.name == "TangfuruImage (" + i + ")")
                        {
                            tangfuruNum = i;
                            potInventory.slots[tangfuruNum].image.color = new Color(1, 1, 1, 0);
                            potInventory.tangfuruSlots[tangfuruNum].image.color = new Color(1, 1, 1, 0);
                        }
                    }
                    

                    ClickFruitImg = hitObj1.GetComponent<Image>();
                    potCompleteFruitsImg.SetActive(true);
                }
            }
        }
        else if(Input.GetMouseButtonUp(0) && hitObj1 != null)
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

            if (results[0].gameObject.tag == "Freezer" && results[0].gameObject != null)
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
                                        potInventory.FullNum -= 1;

                                        

                                    }
                                }
                                
                                
                            }
                        }
                        


                    }
                }
                potInventory.fruits[tangfuruNum] = null; // �����ҿ� ���ķ簡 ���ٸ� ����� ���ķ� �����
                potInventory.slots[tangfuruNum].image.sprite = null;
                potInventory.tangfuruSlots[tangfuruNum].image.sprite = null;

                hitObj1 = null;

            }
            else if (results[0].gameObject == null 
                && potInventory.fruits[tangfuruNum] != null && results[0].gameObject.tag != "Freezer")
            {
                potInventory.slots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                potInventory.tangfuruSlots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                //������ �浹���� �� potinventory ������ ���������((�߰��ϱ�))
            }
            /*if (results[0].gameObject != null && potInventory.fruits[tangfuruNum] != null && results[0].gameObject.tag != "Freezer")*/


            
            hitObj2 = null;
            

        }
    }
}
