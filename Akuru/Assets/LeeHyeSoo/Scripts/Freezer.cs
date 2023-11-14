using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Freezer : MonoBehaviour
{
    public GameObject freezerNum;

    public Text freezertangfuruNum;
    
    FreezeTangfuru freezeTangfuru;
    PopupMessage popupMessage;

    public int index; //≥√¿Â∞Ì ¿Œµ¶Ω∫

    private void Awake()
    {
        freezeTangfuru = FindAnyObjectByType<FreezeTangfuru>();
        popupMessage = FindAnyObjectByType<PopupMessage>();

    }

    private void Start()
    {
        
        
    }

    private void Update()
    {
        freezertangfuruNum.text = GameManager.instance.tangfuruNumList[index].ToString();
    }

    public void ClickFreezer_GoToSalse()
    {
        
        if (GameManager.instance.tangfuruNumList[index] > 0 && GameManager.instance.isFullStand == false)
        {

            GameManager.instance.tangfuruNumList[index] -= 1;
            GameManager.instance.standsNumList[index] += 1;
        }
        else if (GameManager.instance.isFullStand == true)
        {
            popupMessage.IsFreezerFull();
        }
    }
}
