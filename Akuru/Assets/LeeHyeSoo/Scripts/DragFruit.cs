using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragFruit : MonoBehaviour
{
    FreezeTangfuru freezeTangfuru;

    Vector3 returnPosition;
    Image image;

    void Start()
    {
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();
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

            if (freezeTangfuru.ClickFruitImg != null)
            {
                image.sprite = freezeTangfuru.ClickFruitImg.sprite;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            transform.position = returnPosition;
        }

    }

    


}
