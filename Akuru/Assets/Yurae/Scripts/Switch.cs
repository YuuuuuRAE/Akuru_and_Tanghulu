using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Image On;
    public Image Off;


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
