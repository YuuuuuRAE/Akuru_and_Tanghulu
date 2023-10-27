using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FreezeTangfuru : MonoBehaviour, IDragHandler //냄비에서 조리완료 된 탕후루 굳히소로 이동 CS
{
    GraphicRaycaster raycaster; //canvas의 그래픽레이케스터
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    Vector2 returnPosition;

    private void Awake()
    {
        raycaster = GameObject.Find(name: "AT_200Canvas").GetComponent<GraphicRaycaster>();
        eventSystem = FindAnyObjectByType<EventSystem>();
        returnPosition = transform.position;
    }

    private void Update()
    {

        //if (Input.GetMouseButtonUp(0))
        //{
        //    //이벤트 시스템을 포인터이벤트데이터에 셋
        //    pointerEventData = new PointerEventData(eventSystem);

        //    //마우스 포지션을 포인터 이벤트데이터포지션에 셋
        //    pointerEventData.position = Input.mousePosition;

        //    //레이캐스트 리스트 선언
        //    List<RaycastResult> results = new List<RaycastResult>();

        //    //레이캐스트 사용
        //    raycaster.Raycast(pointerEventData, results);

        //    //해당결과 첫 번째 객체 확인
        //    //해당 객체 태그가 Freezer를 포함하면 이벤트 발생
        //    GameObject HitObj1 = results[0].gameObject;
        //    GameObject HitObj2 = results[1].gameObject;
        //    if (HitObj1.gameObject.tag == "Fruit" && HitObj2.gameObject.tag == "Freezer")
        //    {
        //        Debug.Log("굳히소에 탕후루를 놓음 / 충돌한 굳히소:" + HitObj2.gameObject.name);
        //        Destroy(HitObj1.gameObject);
        //    }

        //    //굳히소에 충돌하지 않았으면 원래 있던 자리로 이동
        //    transform.position = returnPosition;


        //    //굳히소가 비어있는상태면 Destroy후 굳히소에 이미지 추가 ((수정하기))
        //    //굳히소가 찬 상태면 반응x, 탕후루 냄비 원래 자리로 돌아감 ((수정하기))
        //}

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
    
