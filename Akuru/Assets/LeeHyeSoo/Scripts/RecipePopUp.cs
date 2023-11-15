using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class RecipePopUp : MonoBehaviour
{
    public List<Image> tangfuruRcpListImg;
    public List<Button> tangfuruRcpListButton;

    UnlockFreezer unlockFreezer;
    Player player;

    private void Awake()
    {
        unlockFreezer = FindAnyObjectByType<UnlockFreezer>();
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
    }

    private void Start()
    {
        for (int i = 0; i < tangfuruRcpListButton.Count; i++)
        {
            tangfuruRcpListButton[i].enabled = false;
        }
    }

    private void Update()
    {
        UplockRcp();
    }
    void UplockRcp()
    {
        for(int i = 2; i < 5 + 1; i++)
        {
            if (GameManager.instance.CurrentLevel == i) //레벨이 1이면
            {
                tangfuruRcpListButton[i - 2].enabled = true;
                tangfuruRcpListImg[i - 2].sprite = player.fruits[i -1].tangfuruRcpImage;
            }
        }

    }



}
