using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TangfuruGoToFreezer : MonoBehaviour
{
    GraphicRaycaster raycaster; //canvas의 그래픽레이케스터
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    FreezeTangfuru freezeTangfuru;
    PotInventory potInventory;
    public int tangfuruNum; //선택된 탕후루 인덱스 저장

    Player player;
    FreezerGroup freezerGroup;

    public GameObject potCompleteFruitsImg; //조리완료된 과일 이미지

    public GameObject hitObj1;
    public GameObject hitObj2;

    public Image ClickFruitImg; //드래그할 때 드래그 이미지를 담을 곳

    
    int FreezerNum = 5; // 냉장고 개수

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
            //이벤트 시스템을 포인터이벤트데이터에 셋
            pointerEventData = new PointerEventData(eventSystem);

            //마우스 포지션을 포인터 이벤트데이터포지션에 셋
            pointerEventData.position = Input.mousePosition;

            //레이캐스트 리스트 선언
            List<RaycastResult> results = new List<RaycastResult>();

            //레이캐스트 사용
            raycaster.Raycast(pointerEventData, results);

            

            //해당결과 첫 번째 객체 확인
            if (results[0].gameObject != null && results[0].gameObject.tag == "Tangfuru" && hitObj2 == null)
            {
                hitObj1 = results[0].gameObject;
                hitObj1Img = hitObj1.GetComponent<Image>();
                if (hitObj1Img.color != ImgClear)
                {
                    Debug.Log("클릭시 안보여야할 탕후루" + hitObj1Img.name); //예) TangfuruImage (7)
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

            //이벤트 시스템을 포인터이벤트데이터에 셋
            pointerEventData = new PointerEventData(eventSystem);

            //마우스 포지션을 포인터 이벤트데이터포지션에 셋
            pointerEventData.position = Input.mousePosition;

            //레이캐스트 리스트 선언
            List<RaycastResult> results = new List<RaycastResult>();

            //레이캐스트 사용
            raycaster.Raycast(pointerEventData, results);

            //해당결과 첫 번째 객체 확인

            bool isFruitinFreezer = false;

            if (results[0].gameObject.tag == "Freezer" && results[0].gameObject != null)
            {
                hitObj2 = results[0].gameObject;
                Debug.Log("굳히소에 탕후루를 놓음 / 충돌한 굳히소:" + results[0].gameObject.name);

                for (int i = 0; i < FreezerNum; i++)
                {
                    if (results[0].gameObject.name == "EmptyFreezerImage (" + i + ")" ) //충돌한 굳히소 인덱스
                    {
                        //freezeTangfuru.FullFreezer(i); //해당 굳히소 찼음으로 전환
                        //freezeTangfuru.tangfuruNumInFreezerNow[i]++;
                        for (int j = 0; j < 20; j++) 
                        {
                            if (hitObj1.name == "TangfuruImage (" + j + ")")
                            {
                                
                                freezerInd = i;
                                Debug.Log("담긴 탕후루냄비위치: " + (hitObj1.name));
                                Image image = hitObj1.GetComponent<Image>(); 
                                Debug.Log("담긴 탕후루종류: " + image.sprite);

                                for (int k = 0; k < player.fruits.Count; k++)
                                {
                                    if (image.sprite.name == player.fruits[k].tangfuruImage.name && player.fruits[k].fruitNum == i) //이미지 이름과 과일이름이 같으면 && 냉장고 인덱스와 과일 인덱스가 같으면
                                    {
                                        freezeTangfuru.FullFreezer(i); //해당 굳히소 찼음으로 전환
                                        freezeTangfuru.tangfuruNumInFreezerNow[i]++;


                                        player.fruits[k].rqQuantityNow++;
                                        
                                        
                                        Debug.Log("굳히는중 / 현재 제작수량: "
                                            + player.fruits[k].rqQuantityNow);
                                        potInventory.FullNum -= 1;

                                        freezerGroup.PlusTangfuruInFreezer(i, k);


                                        gameManager.currentExp += player.fruits[k].exp; //탕후루 제작시 exp+
                                        isFruitinFreezer = true;


                                    }
                                    else if (image.sprite.name == player.fruits[k].tangfuruImage.name && player.fruits[k].fruitNum != i)
                                    {
                                        Debug.LogWarning("잘못된 냉장고입니다");
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
                    potInventory.fruits[tangfuruNum] = null; // 굳히소에 탕후루가 담겼다면 냄비속 탕후루 지우기
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
