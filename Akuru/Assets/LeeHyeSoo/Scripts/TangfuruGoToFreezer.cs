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

    RecipeLevelUp recipeLevelUp;

    [Header("굳히소에서 판매소로 이동하는 버튼")]
    public List<GameObject> freezerGotosaleButton; // 활성/비활성화 할때 사용


    public int freezerInd;
    PlayAudio playAudio;
    

    private void Awake()
    {
        raycaster = GameObject.Find(name: "AT_200Canvas").GetComponent<GraphicRaycaster>();
        eventSystem = FindAnyObjectByType<EventSystem>();
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();
        potInventory = FindAnyObjectByType<PotInventory>();
        player = GetComponent<Player>();
        freezerGroup = FindAnyObjectByType<FreezerGroup>();
        playAudio = FindAnyObjectByType<PlayAudio>();
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

            Image hitObj1Img;
            Color ImgClear = new Color(1, 1, 1, 0);

            //해당결과 첫 번째 객체 확인
            if (results[0].gameObject != null && results[0].gameObject.tag == "Tangfuru" && hitObj2 == null)
            {
                for(int i = 0; i<freezerGotosaleButton.Count;i++)
                {
                    freezerGotosaleButton[i].SetActive(false);
                }

                hitObj1 = results[0].gameObject;
                hitObj1Img = hitObj1.GetComponent<Image>();
                if (hitObj1Img.color != ImgClear)
                {
                    for (int i = 0; i < potInventory.slots.Length; i++)
                    {
                        if (hitObj1Img.name == "TangfuruImage (" + i + ")")
                        {
                            tangfuruNum = i;
                            potInventory.slots[tangfuruNum].image.color = new Color(1, 1, 1, 0);
                            potInventory.tangfuruSlots[tangfuruNum].image.color = new Color(1, 1, 1, 0);
                            playAudio.PlayTapping_Sound_re();
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

                for (int i = 0; i < FreezerNum; i++)
                {
                    if (results[0].gameObject.name == "EmptyFreezerImage (" + i + ")" ) //충돌한 굳히소 인덱스
                    {
                        
                        for (int j = 0; j < 20; j++) 
                        {
                            if (hitObj1.name == "TangfuruImage (" + j + ")")
                            {
                                
                                freezerInd = i;
                                Image image = hitObj1.GetComponent<Image>(); 

                                for (int k = 0; k < player.fruits.Count; k++)
                                {
                                    if (image.sprite.name == player.fruits[k].tangfuruImage.name && player.fruits[k].fruitNum == i) //이미지 이름과 과일이름이 같으면 && 냉장고 인덱스와 과일 인덱스가 같으면
                                    {
                                        freezeTangfuru.FullFreezer(i); //해당 굳히소 찼음으로 전환
                                        //freezeTangfuru.tangfuruNumInFreezerNow[i]++;
                                        GameManager.instance.tangfuruNumList[i] += 1;

                                        //player.fruits[k].rqQuantityNow++;
                                        GameManager.instance.tangfuruNowNum_Rcp[k] += 1;
                                        GameManager.instance.tangfuruAllNum_Rcp[k] += 1;


                                        potInventory.FullNum -= 1;

                                        freezerGroup.PlusTangfuruInFreezer(i, k);


                                        GameManager.instance.CurrentXp += player.fruits[k].exp; //탕후루 제작시 exp+
                                        isFruitinFreezer = true;


                                    }
                                    else if (image.sprite.name == player.fruits[k].tangfuruImage.name && player.fruits[k].fruitNum != i)
                                    {
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
                }
                

            }
            else if (potInventory.fruits[tangfuruNum] != null 
                || results[0].gameObject.tag != "Freezer" && results[0].gameObject == null)
            {
                potInventory.slots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                potInventory.tangfuruSlots[tangfuruNum].image.color = new Color(1, 1, 1, 1);
                
            }

            
            hitObj2 = null;

            for (int i = 0; i < freezerGotosaleButton.Count; i++)
            {
                freezerGotosaleButton[i].SetActive(true);
            }
        }
    }

    
}
