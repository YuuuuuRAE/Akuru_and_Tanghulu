using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Image On;
    public Image Off;

    [Header("0 = BGM, 1 = Sound, 2= Vibe")]
    public int Option_num;

    public GameObject OnButt;
    public GameObject OffButt;

    void Update()
    {
        switch (Option_num)
        {
            case 0:
                OnButt.SetActive(GameManager.instance.isBGM);
                OffButt.SetActive(!GameManager.instance.isBGM);
                break;
            case 1:
                OnButt.SetActive(GameManager.instance.isSound);
                OffButt.SetActive(!GameManager.instance.isSound);
                break;
            case 2:
                OnButt.SetActive(GameManager.instance.isVibe);
                OffButt.SetActive(!GameManager.instance.isVibe);
                break;
        }
    }


    public void BGM()
    {
        if(GameManager.instance.isBGM == true)
        {
            
            GameManager.instance.isBGM = false;
            Off.gameObject.SetActive(true);
            On.gameObject.SetActive(false);
        }
        else{
            GameManager.instance.isBGM = true;
            On.gameObject.SetActive(true);
            Off.gameObject.SetActive(false);
        }

    }


    public void Sound()
    {
        if (GameManager.instance.isSound == true)
        {
            GameManager.instance.isSound = false;
            Off.gameObject.SetActive(true);
            On.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.isSound = true;
            On.gameObject.SetActive(true);
            Off.gameObject.SetActive(false);
        }
    }

    public void Vibe()
    {
        if (GameManager.instance.isVibe == true)
        {
            GameManager.instance.isVibe = false;
            Off.gameObject.SetActive(true);
            On.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.isVibe = true;
            On.gameObject.SetActive(true);
            Off.gameObject.SetActive(false);
        }
    }
}
