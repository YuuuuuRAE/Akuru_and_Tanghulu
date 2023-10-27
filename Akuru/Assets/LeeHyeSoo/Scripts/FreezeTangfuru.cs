using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FreezeTangfuru : MonoBehaviour, IDragHandler //���񿡼� �����Ϸ� �� ���ķ� �����ҷ� �̵� CS
{
    GraphicRaycaster raycaster; //canvas�� �׷��ȷ����ɽ���
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
        //    //�̺�Ʈ �ý����� �������̺�Ʈ�����Ϳ� ��
        //    pointerEventData = new PointerEventData(eventSystem);

        //    //���콺 �������� ������ �̺�Ʈ�����������ǿ� ��
        //    pointerEventData.position = Input.mousePosition;

        //    //����ĳ��Ʈ ����Ʈ ����
        //    List<RaycastResult> results = new List<RaycastResult>();

        //    //����ĳ��Ʈ ���
        //    raycaster.Raycast(pointerEventData, results);

        //    //�ش��� ù ��° ��ü Ȯ��
        //    //�ش� ��ü �±װ� Freezer�� �����ϸ� �̺�Ʈ �߻�
        //    GameObject HitObj1 = results[0].gameObject;
        //    GameObject HitObj2 = results[1].gameObject;
        //    if (HitObj1.gameObject.tag == "Fruit" && HitObj2.gameObject.tag == "Freezer")
        //    {
        //        Debug.Log("�����ҿ� ���ķ縦 ���� / �浹�� ������:" + HitObj2.gameObject.name);
        //        Destroy(HitObj1.gameObject);
        //    }

        //    //�����ҿ� �浹���� �ʾ����� ���� �ִ� �ڸ��� �̵�
        //    transform.position = returnPosition;


        //    //�����Ұ� ����ִ»��¸� Destroy�� �����ҿ� �̹��� �߰� ((�����ϱ�))
        //    //�����Ұ� �� ���¸� ����x, ���ķ� ���� ���� �ڸ��� ���ư� ((�����ϱ�))
        //}

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
    
