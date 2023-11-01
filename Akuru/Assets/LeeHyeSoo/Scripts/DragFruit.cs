using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragFruit : MonoBehaviour
{
    TangfuruGoToFreezer tangfuruGoToFreezer;

    Vector3 returnPosition;
    Image image;

    void Start()
    {
        tangfuruGoToFreezer = FindAnyObjectByType<TangfuruGoToFreezer>();
        image = GetComponent<Image>();

    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            returnPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            transform.position = Input.mousePosition;

            if (tangfuruGoToFreezer.ClickFruitImg != null)
            {
                image.sprite = tangfuruGoToFreezer.ClickFruitImg.sprite;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            transform.position = returnPosition;
        }

    }

    


}
