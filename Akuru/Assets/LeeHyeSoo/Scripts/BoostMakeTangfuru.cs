using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMakeTangfuru : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GameObject.Find(name: "Akuru(Player)").GetComponent<Player>();
    }

    public void ClickBoostButton()
    {
        if (player.isMaking && !player.potInventory.isPotFull)
        {
            player.akuruMakingTime += 3;
        }
    }
}
