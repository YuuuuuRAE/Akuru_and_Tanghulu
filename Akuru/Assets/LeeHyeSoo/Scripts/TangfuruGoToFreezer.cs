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
    PotInventory potInventory;
    public int tangfuruNum; //���õ� ���ķ� �ε��� ����

    Player player;
    FreezerGroup freezerGroup;

    public GameObject potCompleteFruitsImg; //�����Ϸ�� ���� �̹���

    public GameObject hitObj1;
    public GameObject hitObj2;

    public Image ClickFruitImg; //�巡���� �� �巡�� �̹����� ���� ��

    
    int FreezerNum = 5; // ����� ����

    GameManager gameManager;
    RecipeLevelUp recipeLevelUp;

    Image hitObj1Img;
    Color ImgClear = new Color(1, 1, 1, 0);

    public int freezerInd;

    private void Awake()
    {
        raycaster = GameObject.Find(name: "AT_200Canvas").GetComponent<GraphicRaycaster>();
        eventSystem = FindAnyObjectByType<EventSystem>();
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();
        potInventory = FindAnyObjectByType<PotInventory>();
        player = GetComponent<Player>();
        freezerGroup = FindAnyObjectByType<FreezerGroup>();
        gameManager = FindAnyObjectByType<GameManager>();
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

            

            //�ش��� ù ��° ��ü Ȯ��
            if (results[0].gameObject != null && results[0].gameObject.tag == "Tangfuru" && hitObj2 == null)
            {
                hitObj1 = results[0].gameObject;
                hitObj1Img = hitObj1.GetComponent<Image>();
                if (hitObj1Img.color != ImgClear)
                {
                    Debug.Log("Ŭ���� �Ⱥ������� ���ķ�" + hitObj1Img.name); //��) TangfuruImage (7)
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

            bool isFruitinFreezer = false;

            if (results[0].gameObject.tag == "Freezer" && results[0].gameObject != null)
            {
                hitObj2 = results[0].gameObject;
                Debug.Log("�����ҿ� ���ķ縦 ���� / �浹�� ������:" + results[0].gameObject.name);

                for (int i = 0; i < FreezerNum; i++)
                {
                    if (results[0].gameObject.name == "EmptyFreezerImage (" + i + ")" ) //�浹�� ������ �ε���
                    {
                        //freezeTangfuru.FullFreezer(i); //�ش� ������ á������ ��ȯ
                        //freezeTangfuru.tangfuruNumInFreezerNow[i]++;
                        for (int j = 0; j < 20; j++) 
                        {
                            if (hitObj1.name == "TangfuruImage (" + j + ")")
                            {
                                
                                freezerInd = i;
                                Debug.Log("��� ���ķ糿����ġ: " + (hitObj1.name));
                                Image image = hitObj1.GetComponent<Image>(); 
                                Debug.Log("��� ���ķ�����: " + image.sprite);

                                for (int k = 0; k < player.fruits.Count; k++)
                                {
                                    if (image.sprite.name == player.fruits[k].tangfuruImage.name && player.fruits[k].fruitNum == i) //�̹��� �̸��� �����̸��� ������ && ����� �ε����� ���� �ε����� ������
                                    {
                                        freezeTangfuru.FullFreezer(i); //�ش� ������ á������ ��ȯ
                                        freezeTangfuru.tangfuruNumInFreezerNow[i]++;


                                        player.fruits[k].rqQuantityNow++;
                                        
                                        
                                        Debug.Log("�������� / ���� ���ۼ���: "
                                            + player.fruits[k].rqQuantityNow);
                                        potInventory.FullNum -= 1;

                                        freezerGroup.PlusTangfuruInFreezer(i, k);


                                        gameManager.currentExp += player.fruits[k].exp; //���ķ� ���۽� exp+
                                        isFruitinFreezer = true;


                                    }
                                    else if (image.sprite.name == player.fruits[k].tangfuruImage.name && player.fruits[k].fruitNum != i)
                                    {
                                        Debug.LogWarning("�߸��� ������Դϴ�");
                                        potInventory.slots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                                        potInventory.tangfuruSlots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                                        isFruitinFreezer = false;
                                    }



                                }
                                
                                
                            }
                        }
                        


                    }
                }

                if(isFruitinFreezer)
                {
                    potInventory.fruits[tangfuruNum] = null; // �����ҿ� ���ķ簡 ���ٸ� ����� ���ķ� �����
                    potInventory.slots[tangfuruNum].image.sprite = null;
                    potInventory.tangfuruSlots[tangfuruNum].image.sprite = null;

                    hitObj1 = null;

                    Debug.LogWarning("hitObj1 = null");
                }
                

            }
            else if (hitObj1 != null && hitObj1Img.color == ImgClear 
                    && results[0].gameObject == null && results[0].gameObject.tag != "Freezer") 
            {
                potInventory.slots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                potInventory.tangfuruSlots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                
            }

            
            hitObj2 = null;
            

        }
    }

    
}
