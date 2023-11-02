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
    RecipeLevelUp recipeLevelUp; //탕후루 제작수량 누적시 사용
    //int tangfuruNum; //선택된 탕후루 인덱스 저장

    Player player;

    public GameObject potCompleteFruitsImg; //조리완료된 과일 이미지

    public GameObject hitObj1;
    public GameObject hitObj2;

    public Image ClickFruitImg;

    //public int tangfuruInFreezer;
    int FreezerNum = 5; // 냉장고 개수

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


        ////((수정작업중))
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

            //이벤트 시스템을 포인터이벤트데이터에 셋
            pointerEventData = new PointerEventData(eventSystem);

            //마우스 포지션을 포인터 이벤트데이터포지션에 셋
            pointerEventData.position = Input.mousePosition;

            //레이캐스트 리스트 선언
            List<RaycastResult> results = new List<RaycastResult>();

            //레이캐스트 사용
            raycaster.Raycast(pointerEventData, results);

            //해당결과 첫 번째 객체 확인

            if (results[0].gameObject != null && results[0].gameObject.tag == "Freezer")
            {
                hitObj2 = results[0].gameObject;
                Debug.Log("굳히소에 탕후루를 놓음 / 충돌한 굳히소:" + results[0].gameObject.name);
                for (int i = 0; i < FreezerNum; i++)
                {
                    if (results[0].gameObject.name == "EmptyFreezerImage (" + i + ")") //충돌한 굳히소 인덱스
                    {
                        freezeTangfuru.FullFreezer(i); //해당 굳히소 찼음으로 전환
                        freezeTangfuru.tangfuruNumInFreezerNow[i]++;
                        for (int j = 0; j < 20; j++) 
                        {
                            if (hitObj1.name == "TangfuruImage (" + j + ")")
                            {
                                Debug.Log("담긴 탕후루냄비위치: " + (hitObj1.name));
                                Image image = hitObj1.GetComponent<Image>(); 
                                Debug.Log("담긴 탕후루종류: " + image.sprite);

                                for (int k = 0; k < player.fruits.Count; k++)
                                {
                                    if (image.sprite.name == player.fruits[k].tangfuruImage.name)
                                    {
                                        player.fruits[k].rqQuantityNow++;
                                        
                                        Debug.Log("굳히는중 / 현재 제작수량: "
                                            + player.fruits[k].rqQuantityNow);
                                    }
                                }
                                
                                //player.fruits[j].rqQuantityNow++;
                                //Debug.Log("굳히는중 / 현재 제작수량: "
                                //    + player.fruits[j].rqQuantityNow++);
                            }
                        }
                        
                        

                    }
                }

                
            }
        }
    }
}
